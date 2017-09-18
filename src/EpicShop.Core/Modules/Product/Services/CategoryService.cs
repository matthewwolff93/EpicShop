using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Services;
using EpicShop.Core.Modules.Product.Models;

namespace EpicShop.Core.Modules.Product.Services
{
    public class CategoryService : BaseService<CategoryModel>, ICategoryService
    {
        public CategoryService(IRepository<CategoryModel> repository) : base(repository)
        {

        }
    }
}