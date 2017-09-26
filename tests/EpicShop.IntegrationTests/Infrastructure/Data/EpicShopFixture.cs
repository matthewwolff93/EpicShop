using System;
using AutoMapper;
using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Extensions;
using EpicShop.Core.Modules.Category.Models;
using EpicShop.Core.Modules.Shop.Models;
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
                .ConfigureDependencyInjection()
                .AddAutoMapper(typeof(BaseModel))
                .AddDbContext<EpicShopContext>(options => options.UseSqlServer(@"Data Source=localhost;Integrated Security=SSPI;Initial Catalog=EpicShop"))
                .BuildServiceProvider();
        }


        public ShopOutputViewModel NewShop()
        {
            return new ShopOutputViewModel
            {
                Name = "EpicShop"+Guid.NewGuid(),
                Description = "We are the next BABA",
                OwnerName = "Ali" + Guid.NewGuid(),
                OwnerEmail = "ali@gmail.com"
            };
        }

        public CategoryOutputViewModel NewCategory(int shopId)
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