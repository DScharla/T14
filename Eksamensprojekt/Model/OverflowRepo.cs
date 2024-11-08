using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Eksamensprojekt.Model
{
    public class OverflowRepo<T> : IRepository<T> where T : Overflow
    {
        public ObservableCollection<T> GetAll()
        {
            ObservableCollection<T> list = new ObservableCollection<T>();
            return list;
        }

        public string GetStringFromDB()
        {
            return "1";
        }

        public List<T> FromStringToType()
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
