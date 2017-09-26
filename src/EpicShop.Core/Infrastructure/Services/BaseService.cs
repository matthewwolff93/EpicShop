using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Extensions;

namespace EpicShop.Core.Infrastructure.Services
{
    public class BaseService<TModel,TInputViewModel,TOutputViewModel> where TModel : BaseModel where TInputViewModel : BaseViewModel where TOutputViewModel : BaseViewModel
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
        public virtual TOutputViewModel FindById(int id)
        {
            TModel model = Repository.FindById(id);
            return model.ToViewModel<TOutputViewModel>();
        }

        /// <summary>
        /// Find all entities
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TOutputViewModel> FindAll()
        {
            IEnumerable<TModel> models = Repository.FindAll();
            return models.ToViewModel<TOutputViewModel>();
        }

        /// <summary>
        /// Find entities based on expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IEnumerable<TOutputViewModel> Find(Expression<Func<TModel, bool>> predicate)
        {
            IEnumerable<TModel> models = Repository.Find(predicate);
            return models.ToViewModel<TOutputViewModel>();
        }

        /// <summary>
        /// Add a new entity
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public virtual TOutputViewModel Add(TInputViewModel viewModel)
        {
            TModel model = viewModel.ToModel<TModel>();
            Repository.Add(model);

            return model.ToViewModel<TOutputViewModel>();
        }

        /// <summary>
        /// Find an entity by Id and update
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="id"></param>
        public virtual void Update(TInputViewModel viewModel, int id)
        {
            //Ensure that entity exist in the database before updating
            TModel currentModel = Repository.FindById(id);
            TModel modelToUpdate = viewModel.ToModel(currentModel);

            Repository.Update(modelToUpdate);
        }

        /// <summary>
        /// Find an entity by Id and soft delete
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(int id)
        {
            Repository.DeleteById(id);
        }
    }
}
