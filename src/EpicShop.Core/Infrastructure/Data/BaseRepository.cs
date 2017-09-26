using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EpicShop.Core.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace EpicShop.Core.Infrastructure.Data
{
    public class BaseRepository<T> where T : BaseModel{

        private readonly EpicShopContext _epicShopContext;
        private readonly DbSet<T> _entities;

        public BaseRepository(EpicShopContext epicShopContext)
        {
            _epicShopContext = epicShopContext;
            _entities = _epicShopContext.Set<T>();
        }

        /// <summary>
        /// Find an entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T FindById(int id)
        {
            T model = _entities.AsNoTracking().SingleOrDefault(x => x.Id == id);

            if (model == null)
            {
                throw new EntityNotFoundExceptions();
            }

            return model;
        }

        /// <summary>
        /// Find all entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> FindAll()
        {
            IEnumerable<T> model = _entities.AsNoTracking().ToList();
            return model;
        }

        /// <summary>
        /// Find entities based on expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> models = _entities.AsNoTracking().Where(predicate);
            return models;
        }

        /// <summary>
        /// Add a new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Add(T entity)
        {
            _entities.Add(entity);
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

        /// <summary>
        /// Find an entity by Id and soft delete
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            T currentModel = FindById(id);
            currentModel.IsDeleted = true;
            currentModel.DeletedDateTime = DateTime.UtcNow;
            Update(currentModel);
        }
    }
}
