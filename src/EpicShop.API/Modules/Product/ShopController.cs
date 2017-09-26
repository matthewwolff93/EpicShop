using EpicShop.API.Infrastructure.Controllers;
using EpicShop.Core.Modules.Product.Models;
using EpicShop.Core.Modules.Product.Services;

namespace EpicShop.API.Modules.Product
{
    public class ProductController : SimpleController<ProductService,ProductModel,ProductInputViewModel>
    {
        public ProductController(ProductService service):base(service)
        {
            
        }
    }
}
