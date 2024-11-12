using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;
using Azure.Core.GeoJson;

namespace Eksamensprojekt.Model
{
    public interface IRepository <T> where T : class
    {
        ObservableCollection<T> GetAll( string getAllQuery, string connectionString) 
        {
            ObservableCollection<T> all = new ObservableCollection<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(getAllQuery, connection);
                connection.Open();
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        all.Add(
                            FromStringToType(reader)
                            );
                    }
                }
            }
            return all;
        }

        string GetStringFromDB();

        T FromStringToType(SqlDataReader reader);
        
        T GetById(string id, string getByIdQuery, string connectionString)
        {
            T getById = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(getByIdQuery, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        getById = FromStringToType(reader);
                    }

                }

            }

            return getById;

        }

        void Add(T entity, string connectionString, string AddQuery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(AddQuery, connection);
                //command.Parameters.AddWithValue("@Id", entity.id);
                connection.Open();
                command.ExecuteNonQuery();

            }
        }

        void Remove(T entity, string connectionString, string RemoveQuery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(RemoveQuery, connection);
                //command.Parameters.AddWithValue("@Id", entity.id);
                connection.Open();
                command.ExecuteNonQuery();

            }
        }

        void Update(T entity, string connectionString, string UpdateQuery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(UpdateQuery, connection);
                //command.Parameters.AddWithValue("@Id", entity.id);
                connection.Open();
                command.ExecuteNonQuery();

            }
        }
    }
}
