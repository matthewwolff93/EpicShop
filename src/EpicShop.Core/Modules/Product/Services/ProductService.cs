using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Services;
using EpicShop.Core.Modules.Product.Models;

namespace EpicShop.Core.Modules.Product.Services
{
    public class ProductService : BaseService<ProductModel, ProductInputViewModel, ProductOutputViewModel>
    {
        public ProductService(BaseRepository<ProductModel> repository) : base(repository)
        {

        }
    }
}
