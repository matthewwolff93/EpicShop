using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Exceptions;

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
        public virtual TModel FindById(int id)
        {
            TModel model = Repository.FindById(id);

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
        public virtual IEnumerable<TModel> FindAll()
        {
            IEnumerable<TModel> models = Repository.FindAll();
            return models;
        }

        /// <summary>
        /// Find entities based on expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate)
        {
            IEnumerable<TModel> models = Repository.Find(predicate);
            return models;
        }

        /// <summary>
        /// Add a new entity
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public virtual TModel Add(TViewModel viewModel)
        {
            TModel model = Mapper.Map<TViewModel, TModel>(viewModel);
            Repository.Add(model);

            return model;
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

            TModel model = Mapper.Map<TViewModel, TModel>(viewModel);
            Repository.Update(model);
        }

        /// <summary>
        /// Find an entity by Id and soft delete
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(int id)
        {
            var entityToDelete = FindById(id);
            entityToDelete.IsDeleted = true;
            entityToDelete.DeletedDateTime = DateTime.UtcNow;
            Repository.Update(entityToDelete);
        }
    }
}
