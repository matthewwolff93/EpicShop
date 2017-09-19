using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Services;
using EpicShop.Core.Modules.Category.Models;

namespace EpicShop.Core.Modules.Category.Services
{
    public class CategoryService : BaseService<CategoryModel>
    {
        public CategoryService(BaseRepository<CategoryModel> repository) : base(repository)
        {

        }
    }
}