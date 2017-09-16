using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Exceptions;

namespace EpicShop.Core.Infrastructure.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseModel
    {
        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public T FindById(int id)
        {
            T result = _repository.FindById(id);

            if (result == null)
            {
                throw new EntityNotFoundExceptions();
            }

            return result;
        }

        public IEnumerable<T> FindAll()
        {
            return _repository.FindAll();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public T Add(T entity)
        {
            return _repository.Add(entity);
        }

        public void Update(T entity)
        {
            //Ensure that entity exist in the database before updating
            FindById(entity.Id);
            _repository.Update(entity);
        }

        public void Delete(T entity)
        {
            //Ensure that entity exist in the database before deleting
            FindById(entity.Id);
            _repository.Delete(entity);
        }
    }
}
