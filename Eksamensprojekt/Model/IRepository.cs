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

        T FromDBToType(SqlDataReader reader);
        
        T GetById(int id);

        int Add(T entity);

        void Remove(T entity);

        void Update(T entity);

    }
}
