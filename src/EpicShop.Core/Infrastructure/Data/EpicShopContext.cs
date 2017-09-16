using System;
using EpicShop.Core.Infrastructure.Extensions;
using EpicShop.Core.Modules.Brand;
using EpicShop.Core.Modules.Product.Models;
using Microsoft.EntityFrameworkCore;

namespace EpicShop.Core.Infrastructure.Data
{
    public class EpicShopContext : DbContext
    {
        public EpicShopContext(DbContextOptions<EpicShopContext> options) : base(options)
        {

        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<BrandModel> Bands { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            ChangeTracker.Entries().UpdateMetadataOnSave();

            return base.SaveChanges();
        }
    }
}