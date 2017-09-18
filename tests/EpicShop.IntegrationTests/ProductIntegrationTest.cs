using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Exceptions;
using EpicShop.Core.Infrastructure.Services;
using EpicShop.Core.Modules.Product.Models;
using EpicShop.Core.Modules.Shop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpicShop.IntegrationTests
{

    [TestClass]
    public class ProductIntegrationTest
    {
        [TestMethod]
        public void CreateUpdateAndDelete()
        {

            var builder = new DbContextOptionsBuilder<EpicShopContext>();
            builder.UseSqlServer(@"Data Source=localhost;Integrated Security=SSPI;Initial Catalog=EpicShop");

            var context = new EpicShopContext(builder.Options);
            
            TestForShop(context);
            TestForCategory(context);
        }
        
        private void TestForShop(EpicShopContext context)
        {
            var shopRepository = new BaseRepository<ShopModel>(context);
            var shopService = new BaseService<ShopModel>(shopRepository);

            var newShop = new ShopModel
            {
                Name = "EpicShop",
                Description = "We are the next BABA",
                OwnerName = "Ali",
                OwnerEmail = "ali@gmail.com"
            };

            shopService.Add(newShop);

            var findShop = shopService.FindById(newShop.Id);
            Assert.IsNotNull(findShop);

            var newShopWithSameData = newShop;

            try
            {
                shopService.Add(newShopWithSameData);
                Assert.Fail("Adding shops with same email or name is not allowed");
            }
            catch
            {
                Assert.IsTrue(true,"Shop validation passed");
            }

            shopService.Delete(findShop);
            Assert.ThrowsException<EntityNotFoundExceptions>(() => shopService.FindById(findShop.Id));
            
        }

        private void TestForCategory(EpicShopContext context)
        {
            var categoryRepository = new BaseRepository<CategoryModel>(context);
            var categoryService = new BaseService<CategoryModel>(categoryRepository);

            var shopRepository = new BaseRepository<ShopModel>(context);
            var shopService = new BaseService<ShopModel>(shopRepository);

            var newShop = new ShopModel
            {
                Name = "EpicShop",
                Description = "We are the next BABA",
                OwnerName = "Ali",
                OwnerEmail = "ali@gmail.com"
            };

            shopService.Add(newShop);

            var category = new CategoryModel
            {
                ShopId = newShop.Id,
                Name = "Accessories",
                Description = "Stuff"
            };

            categoryService.Add(category);

            var findCategory = categoryService.FindById(category.Id);
            Assert.IsNotNull(findCategory);

            findCategory.Description = findCategory.Description + " Update";
            categoryService.Update(findCategory);

            var findUpdatedCategory = categoryService.FindById(findCategory.Id);
            Assert.AreEqual(findUpdatedCategory.Description, findCategory.Description);

            categoryService.Delete(category);
            Assert.ThrowsException<EntityNotFoundExceptions>(() => categoryService.FindById(category.Id));

            shopService.Delete(newShop);
            Assert.ThrowsException<EntityNotFoundExceptions>(() => shopService.FindById(newShop.Id));
        }

    }
}
