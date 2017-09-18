using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EpicShop.Core.Infrastructure.Data
{
    public class BaseRepository<T> where T : BaseModel{
        private readonly EpicShopContext _epicShopContext;

        public BaseRepository(EpicShopContext epicShopContext)
        {
            _epicShopContext = epicShopContext;
        }

        /// <summary>
        /// Find an entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T FindById(int id)
        {
            return _epicShopContext.Set<T>().SingleOrDefault(x => x.Id == id && !x.IsDeleted);
        }

        /// <summary>
        /// Find all entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> FindAll()
        {
            return _epicShopContext.Set<T>().Where(x=> !x.IsDeleted).ToList();
        }

        /// <summary>
        /// Find entities based on expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            //TODO:how to ensure that IS Deleted is applied to this predicate
            return _epicShopContext.Set<T>().Where(predicate);
        }

        /// <summary>
        /// Add a new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Add(T entity)
        {
            _epicShopContext.Set<T>().Add(entity);
            _epicShopContext.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Find an entity by Id and update
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _epicShopContext.Entry(entity).State = EntityState.Modified;
            _epicShopContext.SaveChanges();
        }
    }
}
