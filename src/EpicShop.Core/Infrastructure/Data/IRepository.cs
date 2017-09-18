using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EpicShop.Core.Infrastructure.Data
{
    public interface IRepository<T> where T : BaseModel
    {
        T FindById(int id);
        T Add(T entity);
        IEnumerable<T> FindAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Update(T entity);
    }
}