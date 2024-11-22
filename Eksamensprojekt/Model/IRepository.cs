using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;

namespace Eksamensprojekt.Model
{
    public interface IRepository <T> where T : class
    {

        ObservableCollection<T> GetAll();

        string GetStringFromDB();

        T FromStringToType(SqlDataReader reader);
        
        T GetById(string id);

        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);

    }
}
