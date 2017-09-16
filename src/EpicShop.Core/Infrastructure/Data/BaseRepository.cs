using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EpicShop.Core.Infrastructure.Data
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly EpicShopContext _epicShopContext;

        public BaseRepository(EpicShopContext epicShopContext)
        {
            _epicShopContext = epicShopContext;
        }

        public T FindById(int id)
        {
            return _epicShopContext.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> FindAll()
        {
            return _epicShopContext.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _epicShopContext.Set<T>().Where(predicate);
        }

        public T Add(T entity)
        {
            _epicShopContext.Set<T>().Add(entity);
            _epicShopContext.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            _epicShopContext.Entry(entity).State = EntityState.Modified;
            _epicShopContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _epicShopContext.Set<T>().Remove(entity);
            _epicShopContext.SaveChanges();
        }
    }
}
