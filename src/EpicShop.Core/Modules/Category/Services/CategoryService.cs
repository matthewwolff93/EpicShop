using System.Collections.Generic;
using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Services;
using EpicShop.Core.Modules.Category.Models;

namespace EpicShop.Core.Modules.Category.Services
{
    public class CategoryService : BaseService<CategoryModel,CategoryInputViewModel, CategoryOutputViewModel>
    {
        public CategoryService(BaseRepository<CategoryModel> repository) : base(repository)
        {

        }

        public IEnumerable<CategoryOutputViewModel> FindAllByShopId(int shopId)
        {
            return Find(x => x.ShopId == shopId);
        }
    }
}