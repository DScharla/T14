using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;

namespace Eksamensprojekt.Model
{
    public class OverflowRepo<T> : IRepository<T> where T : Overflow
    {
        private string connectionString;
        public OverflowRepo(string db)
        {
            connectionString = new ConnectionStringDataReader(db).connectionString;
        }
        public ObservableCollection<T> GetAll()
        {
            ObservableCollection<T> list = new ObservableCollection<T>();
            return list;
        }

        public string GetStringFromDB()
        {
            return "1";
        }

        public T FromStringToType(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(T entity)
        {
            throw new NotImplementedException();
        }


        public bool Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
