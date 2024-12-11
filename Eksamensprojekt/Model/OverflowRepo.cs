using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;
using System.IO;

namespace Eksamensprojekt.Model
{
    public class OverflowRepo<T> : IRepository<T> where T : Overflow
    {
        private string connectionString;
        public OverflowRepo(string db)
        {
            connectionString = new ConnectionStringDataReader(db).connectionString;
            absolutePath = GetPathOfCsv();
            //FromCsvToOverflow(@"/Vejen_OB208 - Overløbsregistrering.txt");
        }

        private readonly static string directoryCurrentPath = Directory.GetCurrentDirectory();
        private readonly string absolutePath;

        public string GetPathOfCsv()
        {
            string tempDirectory = directoryCurrentPath;
            for (int i = 0; i < 3; i++)
            {
                tempDirectory = Directory.GetParent(tempDirectory).ToString();
            }
            return tempDirectory;
        }

        public void FromCsvToOverflow(string fileName, int facilityID)
        {
            List <string> dateTime = new List<string>();
            List<string> overflows = new List<string>();
            string line;
            using (StreamReader sr = new StreamReader(absolutePath + fileName))
            {
                sr.ReadLine();
                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    string[] commaSplits;
                    commaSplits = line.Split("\"");
                    string date = commaSplits[3];
                    string[] tSplit;
                    tSplit = date.Split("T");
                    dateTime.Add(tSplit[0] + " " + tSplit[1]);
                    string sub1 = commaSplits[6].Substring(2);
                    overflows.Add(sub1.Split("]")[0]);                     
                }
                
            }
            int i = 0;
            foreach (string s in dateTime)
            {
                if (double.Parse(overflows[i]) > 0.0)
                {

                    Overflow overflow = new Overflow(dateTime[i], dateTime[i + 1], overflows[i]) { FacilityID = facilityID};
                    Add((T)overflow);
                }
                i++;
            }

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
