using System.Collections.Generic;
using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Services;
using EpicShop.Core.Modules.Category.Models;

namespace EpicShop.Core.Modules.Category.Services
{
    public class CategoryService : BaseService<CategoryModel,CategoryViewModel, CategoryViewModel>
    {
        public CategoryService(BaseRepository<CategoryModel> repository) : base(repository)
        {

        }

        public IEnumerable<CategoryViewModel> FindAllByShopId(int shopId)
        {
            return Find(x => x.ShopId == shopId);
        }
    }
}