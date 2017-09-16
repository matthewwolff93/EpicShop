using System;
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

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedDateTime").CurrentValue = DateTime.UtcNow;
                    entry.Property("UpdatedDateTime").CurrentValue = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
                {
                    entry.Property("UpdatedDateTime").CurrentValue = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }
    }
}