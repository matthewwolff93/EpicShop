using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Extensions;
using EpicShop.Core.Modules.Shop.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EpicShop.IntegrationTests.Infrastructure.Test
{
    public class BaseUnitTest
    {
        protected ServiceProvider ServiceProvider { get; }

        public BaseUnitTest()
        {
            ServiceProvider = new ServiceCollection()
                .AddDependencyInjection()
                .AddAutoMapper(typeof(BaseModel))
                .AddDbContext<EpicShopContext>(options => options.UseSqlServer(@"Data Source=localhost;Integrated Security=SSPI;Initial Catalog=EpicShop"))
                .BuildServiceProvider();

        }
    }
}
