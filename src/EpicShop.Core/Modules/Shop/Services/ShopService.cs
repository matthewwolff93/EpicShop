using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Services;
using EpicShop.Core.Modules.Shop.Models;

namespace EpicShop.Core.Modules.Shop.Services
{
    public class ShopService : BaseService<ShopModel>, IShopService
    {
        public ShopService(IRepository<ShopModel> repository) : base(repository)
        {

        }

    }
}
