using ElectronComponent.ISql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronComponent.Sql
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly string _connectionString;

        public   ComponentRepository()
        {

            this._connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public Component CreateComponent(Component component)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    component.id = Guid.NewGuid();
                    command.CommandText = "insert into Component (id, name, type_id, user_id) values (@id, @name, @type_id, @user_id)";
                    command.Parameters.AddWithValue("@id", component.id);
                    command.Parameters.AddWithValue("@name", component.name);
                    command.Parameters.AddWithValue("@type_id", component.type);
                    command.Parameters.AddWithValue("@user_id", component.Owner.id);
                    command.ExecuteNonQuery();
                    return component;
                }
            }
        }

        public void DellComponent(Guid id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "delete from Component where id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Component GetComponent(Guid id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "Select * from Component where id= @id";
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            return new Component
                            {
                                id = reader.GetGuid(reader.GetOrdinal("id")),
                                name = reader.GetString(reader.GetOrdinal("name")),
                                type = reader.GetGuid(reader.GetOrdinal("type_id"))
    
                            };
                        }

                    }
                }
            }
            throw new ArgumentException($"Злемент с id {id} не найден!");
        }

        public Component UpdateComponent(Component component)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "Update Component Set" +
                        " name=@name," +
                        " type_id=@type_id " +
                        " Where id=@id ";
                    command.Parameters.AddWithValue("@name", component.name);
                    command.Parameters.AddWithValue("@type_id", component.type);
                    command.Parameters.AddWithValue("@id", component.id);
                    command.ExecuteNonQuery();
                    return component;
                }
            }
        }

   

    }
}
