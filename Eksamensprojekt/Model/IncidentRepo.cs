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

                    SqlParameter incidentIDParam = new SqlParameter("@IncidentID", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
                    executeCommand.Parameters.Add(incidentIDParam);

                    connection.Open();

                    executeCommand.ExecuteNonQuery();
                    incident.IncidentID = (int)incidentIDParam.Value;



                }
            }
            return incident.IncidentID;
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
                    executeCommand.Parameters.AddWithValue("@IncidentID", entity.IncidentID);

                    connection.Open();

                    executeCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
