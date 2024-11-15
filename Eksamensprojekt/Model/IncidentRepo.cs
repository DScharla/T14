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
        public ObservableCollection<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public string GetStringFromDB()
        {
            throw new NotImplementedException();
        }

        public T FromStringToType(SqlDataReader reader)
        {
            throw new NotImplementedException();
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
