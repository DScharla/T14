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
            Facility facility = (Facility)entity;
            int systemID;
            string GetSystemIDQuery = $"SELECT SystemID FROM SYSTEM WHERE Text='{facility.System}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand getSystemID = new SqlCommand(GetSystemIDQuery, connection);
                connection.Open();

                systemID = (int)getSystemID.ExecuteScalar();
            }
            string UpdateQuery = $"EXEC uspUpdateFacility @FacilityID = {facility.ID}, @NumberOfIncidents = {facility.NumberOfIncidents}, @TotalOverflow = {facility.TotalOverflow}, @Name = \'{facility.Name}\', @UDLNumber = \'{facility.UDLNumber}\', @OBNumber = \'{entity.OBNumber}\', @MinimumPoolSize=\'{entity.MinimumPoolSize}\', @SystemID = {systemID};";
            if (facility.NumberOfIncidents == null || facility.TotalOverflow == null)
            {
                if (facility.TotalOverflow == null && facility.NumberOfIncidents == null)
                {
                    UpdateQuery = $"EXEC uspUpdateFacility @FacilityID = {facility.ID}, @NumberOfIncidents = Null, @TotalOverflow = Null, @Name = \'{facility.Name}\', @UDLNumber = \'{facility.UDLNumber}\', @OBNumber = \'{entity.OBNumber}\', @MinimumPoolSize=\'{entity.MinimumPoolSize}\', @SystemID = {systemID};";
                }
                else if (facility.TotalOverflow == null)
                {
                    UpdateQuery = $"EXEC uspUpdateFacility @FacilityID = {facility.ID}, @NumberOfIncidents = {facility.NumberOfIncidents}, @TotalOverflow = Null, @Name = \'{facility.Name}\', @UDLNumber = \'{facility.UDLNumber}\', @OBNumber = \'{entity.OBNumber}\', @MinimumPoolSize=\'{entity.MinimumPoolSize}\', @SystemID = {systemID};";
                }
                else if (facility.NumberOfIncidents == null)
                {
                    UpdateQuery = $"EXEC uspUpdateFacility @FacilityID = {facility.ID}, @NumberOfIncidents = Null, @TotalOverflow = {facility.TotalOverflow}, @Name = \'{facility.Name}\', @UDLNumber = \'{facility.UDLNumber}\', @OBNumber = \'{entity.OBNumber}\', @MinimumPoolSize=\'{entity.MinimumPoolSize}\', @SystemID = {systemID};";
                }
               
            }
                


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                SqlCommand UpdateFacility = new SqlCommand(UpdateQuery, connection);
                connection.Open();
                UpdateFacility.ExecuteScalar();

            }
        }
    }
}
