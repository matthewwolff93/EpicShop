using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Exceptions;

namespace EpicShop.Core.Infrastructure.Services
{
    public class BaseService<T> where T : BaseModel
    {
        protected readonly BaseRepository<T> Repository;

        public BaseService(BaseRepository<T> repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Find an entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T FindById(int id)
        {
            T result = Repository.FindById(id);

            if (result == null)
            {
                throw new EntityNotFoundExceptions();
            }

            return result;
        }

        /// <summary>
        /// Find all entities
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> FindAll()
        {
            return Repository.FindAll();
        }

        /// <summary>
        /// Find entities based on expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Repository.Find(predicate);
        }

        /// <summary>
        /// Add a new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual T Add(T entity)
        {
            return Repository.Add(entity);
        }

        /// <summary>
        /// Find an entity by Id and update
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            //Ensure that entity exist in the database before updating
            FindById(entity.Id);
            Repository.Update(entity);
        }

        /// <summary>
        /// Find an entity by Id and soft delete
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            var entityToDelete = FindById(entity.Id);
            entityToDelete.IsDeleted = true;
            Repository.Update(entity);
        }
    }
}
