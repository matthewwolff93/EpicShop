using EpicShop.Core.Infrastructure.Extensions;
using EpicShop.Core.Modules.Category.Models;
using EpicShop.Core.Modules.Product.Models;
using EpicShop.Core.Modules.Shop.Models;
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
        public DbSet<ShopModel> Shop { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            ChangeTracker.Entries().UpdateMetadataOnSave();

            return base.SaveChanges();
        }
    }
}