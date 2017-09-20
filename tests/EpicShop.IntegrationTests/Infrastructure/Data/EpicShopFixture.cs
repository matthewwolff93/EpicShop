using System;
using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Modules.Category.Models;
using EpicShop.Core.Modules.Category.Services;
using EpicShop.Core.Modules.Product.Services;
using EpicShop.Core.Modules.Shop.Models;
using EpicShop.Core.Modules.Shop.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EpicShop.IntegrationTests.Infrastructure.Data
{
    public class EpicShopFixture
    {

        public ServiceProvider ServiceProvider { get; }

        public EpicShopFixture()
        {
            ServiceProvider = new ServiceCollection()
                .AddTransient<CategoryService>()
                .AddTransient<ProductService>()
                .AddTransient<ShopService>()
                .AddTransient<BaseRepository<ShopModel>>()
                .AddTransient<BaseRepository<CategoryModel>>()
                .AddDbContext<EpicShopContext>(options => options.UseSqlServer(@"Data Source=localhost;Integrated Security=SSPI;Initial Catalog=EpicShop"))
                .BuildServiceProvider();
        }


        public ShopModel NewShop()
        {
            return new ShopModel
            {
                Name = "EpicShop"+Guid.NewGuid(),
                Description = "We are the next BABA",
                OwnerName = "Ali" + Guid.NewGuid(),
                OwnerEmail = "ali@gmail.com"
            };
        }

        public CategoryModel NewCategory()
        {
            return new CategoryModel
            {
                Name = "EpicShop" + Guid.NewGuid(),
                Description = "We are the next BABA",
            };
        }

    }
    
}