using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Exceptions;

namespace EpicShop.Core.Infrastructure.Services
{
    public class BaseService<T> where T : BaseModel
    {
        private readonly BaseRepository<T> _repository;

        public BaseService(BaseRepository<T> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Find an entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T FindById(int id)
        {
            T result = _repository.FindById(id);

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
        public IEnumerable<T> FindAll()
        {
            return _repository.FindAll();
        }

        /// <summary>
        /// Find entities based on expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        /// <summary>
        /// Add a new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Add(T entity)
        {
            return _repository.Add(entity);
        }

        /// <summary>
        /// Find an entity by Id and update
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            //Ensure that entity exist in the database before updating
            FindById(entity.Id);
            _repository.Update(entity);
        }

        /// <summary>
        /// Find an entity by Id and soft delete
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            var entityToDelete = FindById(entity.Id);
            entityToDelete.IsDeleted = true;
            _repository.Update(entity);
        }
    }
}
