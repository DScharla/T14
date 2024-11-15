using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt.Model
{
    public class RestrictionRepo<T> : IRepository<T> where T : Restriction
    {
        private string getAllQuery = "SELECT * FROM RESTRICTION";
        private string connectionString = "Server=DESKTOP-TO8KUCB\\SQLEXPRESS;Database=VF;Integrated Security=True;TrustServerCertificate=True;";
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
            Restriction entity = new Restriction();
            entity.StartDate = (DateTime)reader["StartDate"];
            entity.EndDate = (DateTime)reader["EndDate"];
            entity.AllowedAverageIncidents = (int)reader["AllowedAverageIncidents"];
            entity.AllowedAverageIncidentsPeriod = (DateTime)reader["AllowedAverageIncidentsPeriod"];
            entity.AllowedYearlyIncidents = (int)reader["AllowedYearlyIncidents"];
            entity.AllowedAverageOverflowVolume = (int)reader["AllowedAverageOverflowVolume"];
            entity.AllowedAverageOverflowPeriod = (DateTime)reader["AllowedAverageOverflowPeriod"];
            entity.AllowedYearlyOverflowVolume = (int)reader["AllowedYearlyOverflowVolume"];
            entity.EquipmentRestriction = (string)reader["EquipmentRestriction"];
            entity.MaintenanceRestriction = (string)reader["MaintenanceRestriction"];
            entity.MeasurementRestriction = (string)reader["MeasurementRestriction"];
            entity.AdditionalRestriction = (string)reader["AdditionalRestriction"];
            entity.FacilityID = (int)reader["FacilityID"];
            return (T)entity;
        }

        public T GetById(string id)
        {
            throw new NotImplementedException();
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
