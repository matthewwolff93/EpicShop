using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Modules.Product.Models;
using EpicShop.Core.Modules.Product.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpicShop.IntegrationTests
{
    [TestClass]
    public class ProductIntegrationTest
    {
        [TestMethod]
        public void CreateAndUpdateTestMethod()
        {
            var builder = new DbContextOptionsBuilder<EpicShopContext>();
            builder.UseSqlServer(@"Data Source=localhost;Integrated Security=SSPI;Initial Catalog=EpicShop");

            var context = new EpicShopContext(builder.Options);

            var repository = new BaseRepository<ProductModel>(context);
            var service = new ProductService(repository);


            var product = new ProductModel
            {
                Description = "Description",
                Name = "Name",
                UpdatedBy = "UpdatedBy",
                CreatedBy = "CreatedBy"
            };


            var newProduct = service.Add(product);
            Assert.IsNotNull(newProduct);

            var currentProduct = service.FindById(newProduct.Id);
            Assert.IsNotNull(currentProduct);

            currentProduct.Description = "This is new description";

            service.Update(currentProduct);

            var updatedProduct = service.FindById(newProduct.Id);

            Assert.IsNotNull(updatedProduct);
            Assert.AreEqual(updatedProduct.Description,currentProduct.Description);


        }
    }
}
