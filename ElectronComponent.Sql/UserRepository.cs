using ElectronComponent.ISql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronComponent.Sql
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        IComponentRepository componentRepository;
        IComponentTypeRepository componentTypeRepository;
        public UserRepository()
        {
            componentRepository = new ComponentRepository();
            componentTypeRepository = new ComponentTypeRepository();
            this._connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public IEnumerable<Component> GetComponentsofUser(Guid id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "select *from Component where user_id = @id";
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return  new Component
                            {
                                id = reader.GetGuid(reader.GetOrdinal("id")),
                                name = reader.GetString(reader.GetOrdinal("name")),
                                type = reader.GetGuid(reader.GetOrdinal("type_id")),
                                Owner= GetUser(id)

                            };
                        }

                    }
                }
            }
        }

        public User GetUser(string login, string password)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "select *from [User] where login = @login AND password=@password";
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;


                        var user = new User
                        {
                            id = reader.GetGuid(reader.GetOrdinal("id")),
                            firstname = reader.GetString(reader.GetOrdinal("name")),
                            login = reader.GetString(reader.GetOrdinal("login")),
                            password = reader.GetString(reader.GetOrdinal("password"))
                        };
                        return user;
                    }
                }
            }
        }

        public User GetUser(Guid id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "select *from [User] where id = @id";
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new InvalidOperationException("Пользователь не найден!");

                        var user = new User
                        {
                            id = reader.GetGuid(reader.GetOrdinal("id")),
                            firstname = reader.GetString(reader.GetOrdinal("name")),
                            login = reader.GetString(reader.GetOrdinal("login")),
                            password = reader.GetString(reader.GetOrdinal("password"))
                        };
                        return user;
                    }
                }
            }
        }

        public User GreateUser(User user)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    user.id = Guid.NewGuid();
                    command.CommandText = "insert into [User] (id, name, login, password) values (@id, @name, @login, @password)";
                    command.Parameters.AddWithValue("@id", user.id);
                    command.Parameters.AddWithValue("@name", user.firstname);
                    command.Parameters.AddWithValue("@login", user.login);
                    command.Parameters.AddWithValue("@password", user.password);
                    command.ExecuteNonQuery();
                    return user;
                }
            }
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ComponentType> GetTypeComponentsofUser(Guid id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "select *from TypeComponent where user_id = @id";
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new ComponentType
                            {
                                id = reader.GetGuid(reader.GetOrdinal("id")),
                                name = reader.GetString(reader.GetOrdinal("name")),
                                components = componentTypeRepository.GetComponentsofType(reader.GetGuid(reader.GetOrdinal("id")))


                            };
                        }

                    }
                }
            }
        }

    }
}
