using EpicShop.Core.Infrastructure.Exceptions;
using EpicShop.Core.Modules.Category.Models;
using EpicShop.Core.Modules.Category.Services;
using EpicShop.Core.Modules.Shop.Services;
using EpicShop.IntegrationTests.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EpicShop.IntegrationTests.Modules.Category
{
    public class CategoryUnitTest : IClassFixture<EpicShopFixture>
    {
        private readonly EpicShopFixture _epicShopFixture;
        private readonly ShopService _shopService;
        private readonly CategoryService _categoryService;

        public CategoryUnitTest(EpicShopFixture epicShopFixture)
        {
            _epicShopFixture = epicShopFixture;
            _shopService = _epicShopFixture.ServiceProvider.GetService<ShopService>();
            _categoryService = _epicShopFixture.ServiceProvider.GetService<CategoryService>();
        }


        [Fact]
        public void ShouldCreateNewCategory()
        {
            var newShop = _epicShopFixture.NewShop();
            _shopService.Add(newShop);

            var newCategory = _epicShopFixture.NewCategory();
            newCategory.ShopId = newShop.Id;

            _categoryService.Add(newCategory);
            Assert.True(newShop.Id > 0);
        }

        [Fact]
        public void ShouldFindNewCategory()
        {
            var newShop = _epicShopFixture.NewShop();
            _shopService.Add(newShop);

            var newCategory = _epicShopFixture.NewCategory();
            newCategory.ShopId = newShop.Id;

            _categoryService.Add(newCategory);
            Assert.True(newCategory.Id > 0);

            var findCategory = _categoryService.FindById(newCategory.Id);
            Assert.NotNull(findCategory);
            Assert.Equal(findCategory, newCategory);
        }

        [Fact]
        public void ShouldUpdateNewCategory()
        {
            var newShop = _epicShopFixture.NewShop();
            _shopService.Add(newShop);

            var newCategory = _epicShopFixture.NewCategory();
            newCategory.ShopId = newShop.Id;
            _categoryService.Add(newCategory);
            Assert.True(newCategory.Id > 0);

            var findCategory = _categoryService.FindById(newCategory.Id);
            findCategory.Description = "abc";
            _categoryService.Update(findCategory);

            var updated = _categoryService.FindById(findCategory.Id);
            Assert.Equal(updated, findCategory);
        }

        [Fact]
        public void ShouldDeleteNewShop()
        {
            var newShop = _epicShopFixture.NewShop();
            _shopService.Add(newShop);
            var newCategory = _epicShopFixture.NewCategory();
            newCategory.ShopId = newShop.Id;
            _categoryService.Add(newCategory);
            _categoryService.Delete(newCategory);

            CategoryModel categoryModel = null;

            try
            {
                categoryModel = _categoryService.FindById(newCategory.Id);
                Assert.True(false,"The should have been deleted");
            }
            catch (EntityNotFoundExceptions)
            {
                Assert.Null(categoryModel);
            }

        }

    }
}