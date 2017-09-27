using EpicShop.API.Infrastructure.Controllers;
using EpicShop.Core.Infrastructure.Configuration;
using EpicShop.Core.Modules.Category.Models;
using EpicShop.Core.Modules.Category.Services;
using Microsoft.Extensions.Options;

namespace EpicShop.API.Modules.Category
{
    public class CategoryController : SimpleController<CategoryService, CategoryModel, CategoryInputViewModel>
    {
        public CategoryController(CategoryService service,IOptions<AppConfiguration> options) :base(service)
        {
            
        }
    }
}
