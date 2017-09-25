using System;
using AutoMapper;
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
                .AddScoped<CategoryService>()
                .AddScoped<ProductService>()
                .AddScoped<ShopService>()
                .AddScoped<BaseRepository<ShopModel>>()
                .AddScoped<BaseRepository<CategoryModel>>()
            .AddAutoMapper(typeof(EpicShopFixture))
                .AddDbContext<EpicShopContext>(options => options.UseSqlServer(@"Data Source=localhost;Integrated Security=SSPI;Initial Catalog=EpicShop"))
                .BuildServiceProvider();
        }


        public ShopViewModel NewShop()
        {
            return new ShopViewModel
            {
                Name = "EpicShop"+Guid.NewGuid(),
                Description = "We are the next BABA",
                OwnerName = "Ali" + Guid.NewGuid(),
                OwnerEmail = "ali@gmail.com"
            };
        }

        public CategoryViewModel NewCategory(int shopId)
        {
            return new CategoryViewModel
            {
                ShopId = shopId,
                Name = "EpicShop" + Guid.NewGuid(),
                Description = "We are the next BABA",
            };
        }

    }
    
}