using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Eksamensprojekt.Model
{
    public interface IRepository <T> where T : class
    {
        ObservableCollection<T> GetAll();

        string GetStringFromDB();

        List<T> FromStringToType();
        
        T GetById(string id);

        T Add(T entity);

        T Remove(T entity);

        T Update(T entity);
    }
}
