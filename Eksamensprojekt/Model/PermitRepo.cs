using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt.Model
{
    public class PermitRepo<T> : IRepository<T> where T : Permit
    {
        private string getAllQuery = "SELECT * FROM vwPermit";

        private string connectionString;
        public PermitRepo(string db)
        {
            connectionString = new ConnectionStringDataReader(db).connectionString;
        }
        public ObservableCollection<T> GetAll()
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

        public string GetStringFromDB()
        {
            return "1";
        }

        public T FromStringToType(SqlDataReader reader)
        {
            Permit entity = new Permit();
            entity.StartDate = (DateTime)reader["StartDate"];
            try { entity.EndDate = (DateTime)reader["EndDate"]; }
            catch { entity.EndDate = null; }
            try { entity.AllowedAverageIncidents = (int)reader["AllowedAverageIncidents"]; }
            catch { entity.AllowedAverageIncidents = null; }
            try { entity.AllowedAverageIncidentsPeriod = (DateTime)reader["AllowedAverageIncidentsPeriod"]; }
            catch { entity.AllowedAverageIncidentsPeriod = null; }
            entity.AllowedYearlyIncidents = (int)reader["AllowedYearlyIncidents"];
            try { entity.AllowedAverageOverflowVolume = (int)reader["AllowedAverageOverflowVolume"]; }
            catch { entity.AllowedAverageOverflowVolume = null; }
            try { entity.AllowedAverageOverflowPeriod = (DateTime)reader["AllowedAverageOverflowPeriod"]; }
            catch { entity.AllowedAverageOverflowPeriod = null; }
            entity.AllowedYearlyOverflowVolume = (int)reader["AllowedYearlyOverflowVolume"];
            try { entity.EquipmentRestriction = (string)reader["EquipmentRestriction"]; }
            catch { entity.EquipmentRestriction = null; }
            try { entity.MaintenanceRestriction = (string)reader["MaintenanceRestriction"]; }
            catch { entity.MaintenanceRestriction = null; }
            try { entity.MeasurementRestriction = (string)reader["MeasurementRestriction"]; }
            catch { entity.MeasurementRestriction = null; }

            try { entity.AdditionalRestriction = (string)reader["AdditionalRestriction"]; }
            catch { entity.AdditionalRestriction = null; }
            entity.FacilityID = (int)reader["FacilityID"];
            return (T)entity;
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(T entity)
        {
            Permit permit = (Permit)entity;
            int newID;
            string AddQuery = $"EXEC uspAddPermit @StartDate = \'{entity.StartDate}\', @EndDate=\'{entity.EndDate}\', @AllowedYearlyOverflowVolume = {entity.AllowedYearlyOverflowVolume}, @AllowedYearlyIncidents={entity.AllowedYearlyIncidents}, @EquipmentRestrictionID=1, @MaintenanceRestrictionID=1, @MeasurementRestrictionID=1, @AdditionalRestriction=\'{entity.AdditionalRestriction}\', @FacilityName=;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(AddQuery, connection);
                connection.Open();
                newID = (int)command.ExecuteScalar();

            }

            return newID;
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
