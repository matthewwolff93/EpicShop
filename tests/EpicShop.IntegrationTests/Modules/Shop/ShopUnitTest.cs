using System;
using EpicShop.Core.Infrastructure.Exceptions;
using EpicShop.Core.Modules.Shop.Models;
using EpicShop.Core.Modules.Shop.Services;
using EpicShop.IntegrationTests.Infrastructure.Data;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace EpicShop.IntegrationTests.Modules.Shop
{
    public class ShopUnitTest : IClassFixture<EpicShopFixture>
    {
        private readonly EpicShopFixture _epicShopFixture;
        private readonly ShopService _shopService;

        public ShopUnitTest(EpicShopFixture epicShopFixture)
        {
            _epicShopFixture = epicShopFixture;
            _shopService = _epicShopFixture.ServiceProvider.GetService<ShopService>();
        }

        [Fact]
        public void ShouldCreateNewShop()
        {
            var newShop = _epicShopFixture.NewShop();

            _shopService.Add(newShop);
            Assert.True(newShop.Id > 0);
        }

        [Fact]
        public void ShouldFindNewShop()
        {
            var newShop = _epicShopFixture.NewShop();
            _shopService.Add(newShop);
            Assert.True(newShop.Id > 0);

            var findShop = _shopService.FindById(newShop.Id);
            Assert.NotNull(findShop);
            Assert.Equal(findShop,newShop);
        }

        [Fact]
        public void ShouldUpdateNewShop()
        {
            var newShop = _epicShopFixture.NewShop();
            _shopService.Add(newShop);
            var findShop = _shopService.FindById(newShop.Id);
            findShop.Description = "abc";
            _shopService.Update(findShop);

            var updated = _shopService.FindById(findShop.Id);
            Assert.Equal(updated,findShop);
        }

        [Fact]
        public void ShouldDeleteNewShop()
        {
            var newShop = _epicShopFixture.NewShop();
            _shopService.Add(newShop);
            _shopService.Delete(newShop);

            ShopModel deletedShop = null;

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
            var newShop = _epicShopFixture.NewShop();
            var newShopTwo = _epicShopFixture.NewShop();
            newShopTwo.Name = newShop.Name;

            _shopService.Add(newShop);

            try
            {
                _shopService.Add(newShop);

            }
            catch (Exception exception)
            {
            }

        }
    }
}
