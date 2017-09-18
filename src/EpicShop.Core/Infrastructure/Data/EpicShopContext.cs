using EpicShop.Core.Infrastructure.Extensions;
using EpicShop.Core.Modules.Brand;
using EpicShop.Core.Modules.Product.Models;
using EpicShop.Core.Modules.Shop;
using Microsoft.EntityFrameworkCore;

namespace EpicShop.Core.Infrastructure.Data
{
    public class EpicShopContext : DbContext
    {
        public EpicShopContext(DbContextOptions<EpicShopContext> options) : base(options)
        {

        }

        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<BrandModel> Brand { get; set; }
        public DbSet<ShopModel> Shop { get; set; }
        
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            ChangeTracker.Entries().UpdateMetadataOnSave();

            return base.SaveChanges();
        }
    }
}