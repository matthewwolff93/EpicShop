using EpicShop.API.Infrastructure.Controllers;
using EpicShop.Core.Modules.Category.Models;
using EpicShop.Core.Modules.Category.Services;

namespace EpicShop.API.Modules.Category
{
    public class CategoryController : SimpleController<CategoryService, CategoryModel, CategoryInputViewModel>
    {
        public CategoryController(CategoryService service):base(service)
        {
            
        }
    }
}
