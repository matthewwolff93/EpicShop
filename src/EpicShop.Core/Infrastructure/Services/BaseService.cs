using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Exceptions;
using EpicShop.Core.Infrastructure.Extensions;

namespace EpicShop.Core.Infrastructure.Services
{
    public class BaseService<TModel,TViewModel> where TModel : BaseModel where TViewModel : BaseViewModel
    {
        protected readonly BaseRepository<TModel> Repository;

        public BaseService(BaseRepository<TModel> repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Find an entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TViewModel FindById(int id)
        {
            TModel model = Repository.FindById(id);

            if (model == null)
            {
                throw new EntityNotFoundExceptions();
            }

            return model.ToViewModel<TViewModel>();
        }

        /// <summary>
        /// Find all entities
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TViewModel> FindAll()
        {
            IEnumerable<TModel> models = Repository.FindAll();
            return models.ToViewModel<TViewModel>();
        }

        /// <summary>
        /// Find entities based on expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IEnumerable<TViewModel> Find(Expression<Func<TModel, bool>> predicate)
        {
            IEnumerable<TModel> models = Repository.Find(predicate);
            return models.ToViewModel<TViewModel>();
        }

        /// <summary>
        /// Add a new entity
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public virtual TViewModel Add(TViewModel viewModel)
        {
            TModel model = viewModel.ToModel<TModel>();
            Repository.Add(model);

            return model.ToViewModel<TViewModel>();
        }

        /// <summary>
        /// Find an entity by Id and update
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="id"></param>
        public virtual void Update(TViewModel viewModel, int id)
        {
            //Ensure that entity exist in the database before updating
            FindById(id);

            TModel model = viewModel.ToModel<TModel>();
            Repository.Update(model);
        }

        /// <summary>
        /// Find an entity by Id and soft delete
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(int id)
        {
            var entityToDelete = FindById(id).ToModel<TModel>();
            entityToDelete.IsDeleted = true;
            entityToDelete.DeletedDateTime = DateTime.UtcNow;
            Repository.Update(entityToDelete);
        }
    }
}
