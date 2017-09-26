using EpicShop.API.Infrastructure.Controllers;
using EpicShop.Core.Modules.Shop.Models;
using EpicShop.Core.Modules.Shop.Services;

namespace EpicShop.API.Modules.Shop
{
    public class ShopController : SimpleController<ShopService,ShopModel,ShopInputViewModel>
    {

        public ShopController(ShopService shopService):base(shopService)
        {
            
        }

    }
}
