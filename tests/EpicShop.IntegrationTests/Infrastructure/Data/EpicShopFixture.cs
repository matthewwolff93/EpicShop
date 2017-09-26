using System;
using EpicShop.Core.Modules.Category.Models;
using EpicShop.Core.Modules.Shop.Models;

namespace EpicShop.IntegrationTests.Infrastructure.Data
{
    public class EpicShopFixture
    {

        public static ShopInputViewModel NewShop()
        {
            return new ShopInputViewModel
            {
                Name = "EpicShop"+Guid.NewGuid(),
                Description = "We are the next BABA",
                OwnerName = "Ali" + Guid.NewGuid(),
                OwnerEmail = "ali@gmail.com"
            };
        }

        public static CategoryInputViewModel NewCategory(int shopId)
        {
            return new CategoryInputViewModel
            {
                ShopId = shopId,
                Name = "EpicShop" + Guid.NewGuid(),
                Description = "We are the next BABA",
            };
        }

    }
    
}