using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Eksamensprojekt.Model
{
    public class FacilityRepo<T> : IRepository<T> where T : Facility
    {
        public ObservableCollection<T> GetAll()
        {
            throw new NotImplementedException();
        }


        public string GetStringFromDB()
        {
            throw new NotImplementedException();
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
