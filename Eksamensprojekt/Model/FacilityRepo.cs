using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.Xml;
using System.Data.Common;
using System.Data;

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
            entity.SystemID = (int)reader["SystemID"];
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
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                

                using (var executeCommand = new SqlCommand("uspAddFacility", connection))
                {
                    executeCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    executeCommand.Parameters.AddWithValue("@Name", entity.Name);
                    executeCommand.Parameters.AddWithValue("@UDLNumber", entity.UDLNumber);
                    executeCommand.Parameters.AddWithValue("@OBNumber", entity.OBNumber);
                    executeCommand.Parameters.AddWithValue("@MinimumPoolSize", entity.MinimumPoolSize);
                    executeCommand.Parameters.AddWithValue("@SystemID", entity.SystemID);
                    

                    SqlParameter facilityIDParam = new SqlParameter("@FacilityID", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
                    executeCommand.Parameters.Add(facilityIDParam);

                    connection.Open();

                    executeCommand.ExecuteNonQuery();
                    facility.ID = (int)facilityIDParam.Value;
                }           
                 
                             

            }

            return facility.ID;
        }

        public bool Remove(T entity)
        {
            Facility facility = (Facility)entity;
            bool isRemoved = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var executeCommand = new SqlCommand("uspRemoveFacility", connection, transaction))
                    {
                        executeCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        executeCommand.Parameters.AddWithValue("@FacilityID", entity.ID);
                        try
                        {
                            executeCommand.ExecuteNonQuery();
                            isRemoved = true;
                        }
                        catch{ transaction.Rollback(); }
                    }
                }
                
            }
            return isRemoved;
        }


        public void Update(T entity)
        {
            Facility facility = (Facility)entity;
            int systemID;
            string GetSystemIDQuery = $"SELECT SystemID FROM SYSTEM WHERE Text=@text";
                        
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                

                using (var updateCommand = new SqlCommand("uspUpdateFacility", connection))
                {
                    updateCommand.CommandType = CommandType.StoredProcedure;
                                       
                    updateCommand.Parameters.AddWithValue("@FacilityID", facility.ID);
                    updateCommand.Parameters.AddWithValue("@Name", facility.Name);
                    updateCommand.Parameters.AddWithValue("@UDLNumber", facility.UDLNumber);
                    updateCommand.Parameters.AddWithValue("@OBNumber", facility.OBNumber);
                    updateCommand.Parameters.AddWithValue("@MinimumPoolSize", facility.MinimumPoolSize);
                    updateCommand.Parameters.AddWithValue("@SystemID", facility.SystemID);

                    if (facility.TotalOverflow != null)
                    {
                        updateCommand.Parameters.AddWithValue("@TotalOverflow", facility.TotalOverflow);
                    }                    
                    if (facility.NumberOfIncidents != null)
                    {
                        updateCommand.Parameters.AddWithValue("@NumberOfIncidents", facility.NumberOfIncidents);
                    }
                    updateCommand.ExecuteNonQuery();

                }
            }
                                            
                
        }
            


            
                
               
            
                


                
                
            
        }
    }

