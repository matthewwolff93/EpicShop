using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Modules.Category.Models;
using EpicShop.Core.Modules.Category.Services;
using EpicShop.Core.Modules.Product.Services;
using EpicShop.Core.Modules.Shop.Models;
using EpicShop.Core.Modules.Shop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EpicShop.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //TODO: move all this to an extension
            services.AddAutoMapper(typeof(BaseModel));
            services
                .AddScoped<CategoryService>()
                .AddScoped<ProductService>()
                .AddScoped<ShopService>()
                .AddScoped<BaseRepository<ShopModel>>()
                .AddScoped<BaseRepository<CategoryModel>>()
                .AddDbContext<EpicShopContext>(options =>
                    options.UseSqlServer(@"Data Source=localhost;Integrated Security=SSPI;Initial Catalog=EpicShop"));


            Mapper.AssertConfigurationIsValid();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
