using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt.Model
{
    public class IncidentRepo<T> : IRepository<T> where T : Incident
    {
        private string connectionString;
        public IncidentRepo(string db)
        {
            connectionString = new ConnectionStringDataReader(db).connectionString;
        }
        public ObservableCollection<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public string GetStringFromDB()
        {
            throw new NotImplementedException();
        }

        public T FromDBToType(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(T entity)
        {
            Incident incident = (Incident)entity;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                using (var executeCommand = new SqlCommand("uspAddIncident", connection))
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
            Incident incident = (Incident)entity;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                using (var executeCommand = new SqlCommand("uspUpdateIncident", connection))
                {
                    executeCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    executeCommand.Parameters.AddWithValue("@OverflowVolume", entity.OverflowVolume);
                    executeCommand.Parameters.AddWithValue("@EndTime", entity.EndTime);
                    executeCommand.Parameters.AddWithValue("@FacilityID", entity.FacilityID);

                    connection.Open();

                    executeCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
