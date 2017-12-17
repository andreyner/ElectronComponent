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
    public class ComponentTypeRepository : IComponentTypeRepository
    {
      
        private readonly string _connectionString;

        public ComponentTypeRepository()
        {
            this._connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public ComponentType GreateComponentType(ComponentType componentType)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    componentType.id = Guid.NewGuid();
                    command.CommandText = "insert into TypeComponent (id, name, user_id ) values (@id, @name, @user_id )";
                    command.Parameters.AddWithValue("@id", componentType.id);
                    command.Parameters.AddWithValue("@name", componentType.name);
                    command.Parameters.AddWithValue("@user_id", componentType.userid);
                    command.ExecuteNonQuery();
                    return componentType;
                }
            }
        }

        public ComponentType UpdateComponentType(ComponentType componentType)
        {
            throw new NotImplementedException();
        }
        public void DellComponentType(Guid componentTypeid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Component> GetComponentsofType(Guid typeid)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "Select * from Component where type_id= @type_id";
                    command.Parameters.AddWithValue("@type_id", typeid);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            yield return new Component
                            {
                                id = reader.GetGuid(reader.GetOrdinal("id")),
                                name = reader.GetString(reader.GetOrdinal("name")),
                                type = reader.GetGuid(reader.GetOrdinal("type_id"))

                            };
                        }

                    }
                }
            }
        }

      
    }
}
