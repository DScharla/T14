﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
            Permit entity = new Permit();
            entity.StartDate = (DateTime)reader["StartDate"];
            try { entity.EndDate = (DateTime)reader["EndDate"]; }
            catch { entity.EndDate = null; }
            try { entity.AllowedAverageIncidents = (int)reader["AllowedAverageIncidents"]; }
            catch { entity.AllowedAverageIncidents = null; }
            try { entity.AllowedAverageIncidentsPeriod = (DateTime)reader["AllowedAverageIncidentsPeriod"]; }
            catch { entity.AllowedAverageIncidentsPeriod = null; }
            try { entity.AllowedYearlyIncidents = (int)reader["AllowedYearlyIncidents"]; }
            catch { entity.AllowedYearlyIncidents = null; }
            try { entity.AllowedAverageOverflowVolume = (int)reader["AllowedAverageOverflowVolume"]; }
            catch { entity.AllowedAverageOverflowVolume = null; }
            try { entity.AllowedAverageOverflowPeriod = (DateTime)reader["AllowedAverageOverflowPeriod"]; }
            catch { entity.AllowedAverageOverflowPeriod = null; }
            try { entity.AllowedYearlyOverflowVolume = (int)reader["AllowedYearlyOverflowVolume"]; }
            catch { entity.AllowedYearlyOverflowVolume = null; }
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
            int equipmentRestrictionID = GetRestrictionIDFromTable("EquipmentRestrictionID", "EQUIPMENTRESTRICTION", entity.EquipmentRestriction);
            int measurementRestrictionID = GetRestrictionIDFromTable("MeasurementRestrictionID", "MEASUREMENTRESTRICTION", entity.MeasurementRestriction);
            int maintenanceRestrictionID = GetRestrictionIDFromTable("MaintenanceRestrictionID", "MAINTENANCERESTRICTION", entity.MaintenanceRestriction);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (var executeCommand = new SqlCommand("uspAddPermit", connection))
                {
                    executeCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    executeCommand.Parameters.AddWithValue("@StartDate", entity.StartDate);
                    if (entity.EndDate != null) { executeCommand.Parameters.AddWithValue("@EndDate", entity.EndDate); };
                    if (entity.AllowedYearlyOverflowVolume != null) { executeCommand.Parameters.AddWithValue("@AllowedYearlyOverflowVolume", entity.AllowedYearlyOverflowVolume); }
                    if (entity.AllowedYearlyIncidents != null) { executeCommand.Parameters.AddWithValue("@AllowedYearlyIncidents", entity.AllowedYearlyIncidents); }
                    executeCommand.Parameters.AddWithValue("@EquipmentRestrictionID", equipmentRestrictionID);
                    executeCommand.Parameters.AddWithValue("@MaintenanceRestrictionID", maintenanceRestrictionID);
                    executeCommand.Parameters.AddWithValue("@MeasurementRestrictionID", measurementRestrictionID);
                    if (entity.AdditionalRestriction != null) { executeCommand.Parameters.AddWithValue("@AdditionalRestriction", entity.AdditionalRestriction); }
                    executeCommand.Parameters.AddWithValue("@FacilityID", entity.FacilityID);

                    SqlParameter permitIDParam = new SqlParameter("@PermitID", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
                    executeCommand.Parameters.Add(permitIDParam);

                    connection.Open();

                    executeCommand.ExecuteNonQuery();
                    permit.PermitID = (int)permitIDParam.Value;
                }
            }
            return permit.PermitID;
        }

        public int GetRestrictionIDFromTable(string columnName, string tableName, string restriction)
        {
            int restrictionID;
            string query = $"SELECT {columnName} FROM {tableName} WHERE Text = \'{restriction}\'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                restrictionID = (int)command.ExecuteScalar();
            }
            return restrictionID;
        }

        public bool Remove(T entity)
        {
            Permit facility = (Permit)entity;
            bool isRemoved = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var executeCommand = new SqlCommand("uspRemovePermit", connection))
                        {
                            executeCommand.CommandType = System.Data.CommandType.StoredProcedure;

                            executeCommand.Parameters.AddWithValue("@PermitID", entity.PermitID);
                            connection.Open();

                            executeCommand.ExecuteNonQuery();
                            isRemoved = true;
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        isRemoved = true;
                    }
                }
            }
            return isRemoved;
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<string> GetRestrictionOptionsFromDB(string RestrictionName)
        {
            ObservableCollection<string> restrictionOptions = new ObservableCollection<string>();
            string getRestrictionOptionsQuery = $"SELECT Text FROM {RestrictionName}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(getRestrictionOptionsQuery, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        restrictionOptions.Add(
                             (string)reader["Text"]
                            );
                    }
                }
            }
            return restrictionOptions;
        }
    }
}
