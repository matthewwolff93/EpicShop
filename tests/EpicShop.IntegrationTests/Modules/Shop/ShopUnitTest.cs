using System;
using EpicShop.Core.Infrastructure.Exceptions;
using EpicShop.Core.Modules.Shop.Models;
using EpicShop.Core.Modules.Shop.Services;
using EpicShop.IntegrationTests.Infrastructure.Data;
using EpicShop.IntegrationTests.Infrastructure.Test;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace EpicShop.IntegrationTests.Modules.Shop
{
    public class ShopUnitTest : BaseUnitTest
    {
        private readonly ShopService _shopService;

        public ShopUnitTest()
        {
            _shopService = ServiceProvider.GetService<ShopService>();
        }

        [Fact]
        public void ShouldCreateNewShop()
        {
            var newShop = _shopService.Add(EpicShopFixture.NewShop());
            Assert.True(newShop.Id > 0);
        }

        [Fact]
        public void ShouldFindNewShop()
        {
            var newShop = _shopService.Add(EpicShopFixture.NewShop());
            Assert.True(newShop.Id > 0);

            var findShop = _shopService.FindById(newShop.Id);
            Assert.NotNull(findShop);
        }

        [Fact]
        public void ShouldUpdateNewShop()
        {
            var newShop = _shopService.Add(EpicShopFixture.NewShop());
            var findShop = _shopService.FindById(newShop.Id);
            findShop.Description = "I updated this";

            _shopService.Update(findShop, findShop.Id);

            var updated = _shopService.FindById(findShop.Id);
            Assert.Equal(updated.Description,findShop.Description);
        }

        [Fact]
        public void ShouldDeleteNewShop()
        {
            var newShop = _shopService.Add(EpicShopFixture.NewShop());
            _shopService.Update(newShop,newShop.Id);
            _shopService.Delete(newShop.Id);

            ShopOutputViewModel deletedShop = null;

            try
            {
                deletedShop = _shopService.FindById(newShop.Id);
                Assert.True(false,"The should should have been deleted");
            }
            catch (EntityNotFoundExceptions)
            {
                Assert.Null(deletedShop);
            }

        }


        [Fact]
        public void ShouldNotAllowForTwoSameNamesForShop()
        {
            var newShop = EpicShopFixture.NewShop();
            var newShopTwo = EpicShopFixture.NewShop();
            newShopTwo.Name = newShop.Name;

            _shopService.Add(newShop);

            try
            {
                _shopService.Add(newShopTwo);
                Assert.True(false, "Adding a shop with the same name is not allowed");
            }
            catch (Exception)
            {
                Assert.True(true, "Adding a shop with the same name was not allowed");
            }

        }
    }
}
