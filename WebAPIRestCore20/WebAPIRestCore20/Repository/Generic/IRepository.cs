using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Model.Base;

namespace WebAPIRestCore20.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindByID(long Id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long Id);
        bool Exist(long? id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
