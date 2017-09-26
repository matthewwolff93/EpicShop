using System.Collections.Generic;
using AutoMapper;
using EpicShop.Core.Infrastructure.Data;

namespace EpicShop.Core.Infrastructure.Extensions
{
    public static class AutoMapperExtensions
    {
        public static TViewModel ToViewModel<TViewModel>(this BaseModel source, TViewModel destination = null) where TViewModel : BaseViewModel
        {
            if (destination != null)
            {
                return Mapper.Map(source, destination);
            }

            return Mapper.Map<BaseModel, TViewModel>(source);
        }

        public static TModel ToModel<TModel>(this BaseViewModel source, TModel destination = null) where TModel : BaseModel
        {
            if (destination != null)
            {
                return Mapper.Map(source, destination);
            }

            return Mapper.Map<BaseViewModel, TModel>(source);
        }

        public static IEnumerable<TViewModel> ToViewModel<TViewModel>(this IEnumerable<BaseModel> model) where TViewModel : BaseViewModel
        {
            return Mapper.Map<IEnumerable<BaseModel>, IEnumerable<TViewModel>>(model);
        }

        public static IEnumerable<TModel> ToModel<TModel>(this IEnumerable<BaseViewModel> viewModel) where TModel : BaseModel
        {
            return Mapper.Map<IEnumerable<BaseViewModel>, IEnumerable<TModel>>(viewModel);
        }
    }
}