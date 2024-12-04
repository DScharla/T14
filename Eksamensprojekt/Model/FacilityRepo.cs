using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.Xml;

namespace Eksamensprojekt.Model
{
    public class FacilityRepo<T> : IRepository<T> where T : Facility
    {
        private string getAllQuery = "SELECT * FROM vwFacility";
        private string connectionString;

        public FacilityRepo(string db)
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
            throw new NotImplementedException();
        }


        public T FromStringToType(SqlDataReader reader)
        {
            Facility entity = new Facility();
            entity.ID = (int)reader["FacilityID"];
            entity.Name = (string)reader["FacilityName"];
            try { entity.NumberOfIncidents = (int)reader["NumberOfIncidents"]; }
            catch { entity.NumberOfIncidents = null; }
            try { entity.TotalOverflow = (int)reader["TotalOverflow"]; }
            catch { entity.TotalOverflow = null; }
            entity.OBNumber = (string)reader["OBNumber"];
            entity.UDLNumber = (string)reader["UDLNumber"];
            try { entity.MinimumPoolSize = (string)reader["MinimumPoolSize"]; }
            catch { entity.MinimumPoolSize = null; }
            
            entity.System = (string)reader["SystemName"];
            

            return (T)entity;

        }


        public T GetById(int id)
        {
            throw new NotImplementedException();
        }


        public int Add(T entity)
        {
            Facility facility = (Facility)entity;
            int newID;
            string AddQuery = $"DECLARE @newFacilityID Int;\nEXEC uspAddFacility @Name = \'{entity.Name}\', @UDLNumber=\'{entity.UDLNumber}\', @OBNumber = \'{entity.OBNumber}\', @MinimumPoolSize=\'{entity.MinimumPoolSize}\', @SystemName=\'{entity.System}\', @FacilityID = @newFacilityID OUTPUT;\nSELECT @newFacilityID;";

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
