using System;
using EpicShop.Core.Modules.Category.Models;
using EpicShop.Core.Modules.Shop.Models;

namespace EpicShop.IntegrationTests.Infrastructure.Data
{
    public class EpicShopFixture
    {

        public static ShopOutputViewModel NewShop()
        {
            return new ShopOutputViewModel
            {
                Name = "EpicShop"+Guid.NewGuid(),
                Description = "We are the next BABA",
                OwnerName = "Ali" + Guid.NewGuid(),
                OwnerEmail = "ali@gmail.com"
            };
        }

        public static CategoryOutputViewModel NewCategory(int shopId)
        {
            return new CategoryOutputViewModel
            {
                ShopId = shopId,
                Name = "EpicShop" + Guid.NewGuid(),
                Description = "We are the next BABA",
            };
        }

    }
    
}