using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt.Model
{ //Object af denne klasse i IRepository
    public class ConnectionStringDataReader
    {
        private readonly static string directoryCurrentPath = Directory.GetCurrentDirectory();
        private readonly string absolutePath;
        public string connectionString;

        public ConnectionStringDataReader(string fileName)
        {
            absolutePath = GetPathOfConnectionString() + @"\" + fileName + ".txt";
            connectionString=ReadConnectionString(absolutePath);
            //connectionstring = "Server=DESKTOP-TO8KUCB\\SQLEXPRESS;Database=VF;Integrated Security=True;TrustServerCertificate=True;";
        }
        public string ReadConnectionString(string absolutePath)
        {
            string s;
            using (StreamReader sr = new StreamReader(absolutePath))
            {
                s = @sr.ReadToEnd();
            }
            return s;
        }
        public string GetPathOfConnectionString()
        {
            string tempDirectory = directoryCurrentPath;
            for (int i = 0; i < 3; i++)
            {
                tempDirectory = Directory.GetParent(tempDirectory).ToString();
            }
            return tempDirectory;
        }
    }
}
