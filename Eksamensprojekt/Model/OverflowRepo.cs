using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;

namespace Eksamensprojekt.Model
{
    public class OverflowRepo<T> : IRepository<T> where T : Overflow
    {
        private string connectionString;
        public OverflowRepo(string db)
        {
            connectionString = new ConnectionStringDataReader(db).connectionString;
        }

        

        public ObservableCollection<T> GetAll()
        {
            ObservableCollection<T> all = new ObservableCollection<T>();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string getAllQuery = "SELECT * FROM OVERFLOW;";

                SqlCommand command = new SqlCommand(getAllQuery, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        all.Add(
                            FromDBToType(reader)
                            );
                    }
                }
            }
            return all;
        }

        public string GetStringFromDB()
        {
            return "1";
        }

        public T FromDBToType(SqlDataReader reader)
        {
            Overflow entity = new Overflow();
            entity.OverflowID = (int)reader["OverflowID"];
            entity.OverflowVolume = (int)reader["OverflowVolume"];
            entity.StartTime = (DateTime)reader["StartTime"];
            entity.EndTime = (DateTime)reader["EndTime"];
            entity.FacilityID = (int)reader["FacilityID"];
            

            return (T)entity;
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(T entity)
        {
            Overflow overflow = (Overflow)entity;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                using (var executeCommand = new SqlCommand("uspAddOverflow", connection))
                {
                    executeCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    executeCommand.Parameters.AddWithValue("@OverflowVolume", entity.OverflowVolume);
                    executeCommand.Parameters.AddWithValue("@StartTime", entity.StartTime);
                    executeCommand.Parameters.AddWithValue("@EndTime", entity.EndTime);
                    executeCommand.Parameters.AddWithValue("@FacilityID", entity.FacilityID);

                    connection.Open();

                    executeCommand.ExecuteNonQuery();
                    
                    return 1;
                }
            }
        }


        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
