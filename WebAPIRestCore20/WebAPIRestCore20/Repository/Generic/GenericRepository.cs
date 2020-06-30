using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Model.Base;
using WebAPIRestCore20.Model.Context;

namespace WebAPIRestCore20.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySqlContext _mySqlContext;
        private DbSet<T> dataset;

        public GenericRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
            dataset = _mySqlContext.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _mySqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public void Delete(int Id)
        {
            var retorno = dataset.SingleOrDefault(p => p.Id == Id);
            try
            {
                if (retorno != null)
                {
                    dataset.Remove(retorno);
                    _mySqlContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exist(long? id)
        {
            return dataset.Any(p => p.Id == id);
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindByID(long Id)
        {
            return dataset.SingleOrDefault(p => p.Id == Id);
        }

        public T Update(T item)
        {
            if (!Exist(item.Id))
            {
                return null;
            }

            var retorno = dataset.SingleOrDefault(p => p.Id == item.Id);
            try
            {
                _mySqlContext.Entry(retorno).CurrentValues.SetValues(item);
                _mySqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
