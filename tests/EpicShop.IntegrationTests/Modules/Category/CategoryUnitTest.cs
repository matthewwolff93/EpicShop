using EpicShop.Core.Infrastructure.Exceptions;
using EpicShop.Core.Infrastructure.Extensions;
using EpicShop.Core.Modules.Category.Models;
using EpicShop.Core.Modules.Category.Services;
using EpicShop.Core.Modules.Shop.Services;
using EpicShop.IntegrationTests.Infrastructure.Data;
using EpicShop.IntegrationTests.Infrastructure.Test;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EpicShop.IntegrationTests.Modules.Category
{
    public class CategoryUnitTest : BaseUnitTest
    {
        private readonly ShopService _shopService;
        private readonly CategoryService _categoryService;

        public CategoryUnitTest()
        {
            _shopService = ServiceProvider.GetService<ShopService>();
            _categoryService = ServiceProvider.GetService<CategoryService>();
        }


        [Fact]
        public void ShouldCreateNewCategory()
        {
            var newShop = _shopService.Add(EpicShopFixture.NewShop());
            var newCategory = EpicShopFixture.NewCategory(newShop.Id);

            _categoryService.Add(newCategory);
            Assert.True(newShop.Id > 0);
        }

        [Fact]
        public void ShouldFindNewCategory()
        {
            var newShop = _shopService.Add(EpicShopFixture.NewShop());

            var newCategory = _categoryService.Add(EpicShopFixture.NewCategory(newShop.Id));
            Assert.True(newCategory.Id > 0);

            var findCategory = _categoryService.FindById(newCategory.Id);
            Assert.NotNull(findCategory);
        }

        [Fact]
        public void ShouldUpdateNewCategory()
        {
            var newShop = _shopService.Add(EpicShopFixture.NewShop());

            var newCategory = _categoryService.Add(EpicShopFixture.NewCategory(newShop.Id));
            Assert.True(newCategory.Id > 0);

            CategoryModel findCategory = _categoryService.FindById(newCategory.Id);
            findCategory.Description = "abc";

            _categoryService.Update(findCategory.ToViewModel<CategoryInputViewModel>(), findCategory.Id);

            var updated = _categoryService.FindById(findCategory.Id);
            Assert.Equal(updated.Description, findCategory.Description);
        }

        [Fact]
        public void ShouldDeleteNewShop()
        {
            var newShop = _shopService.Add(EpicShopFixture.NewShop());
            var newCategory = _categoryService.Add(EpicShopFixture.NewCategory(newShop.Id));
            _categoryService.Delete(newCategory.Id);

            CategoryModel categoryModel = null;

            try
            {
                categoryModel = _categoryService.FindById(newCategory.Id);
                Assert.True(false, "The should have been deleted");
            }
            catch (EntityNotFoundExceptions)
            {
                Assert.Null(categoryModel);
            }

        }

    }
}
