using EpicShop.Core.Infrastructure.Extensions;
using EpicShop.Core.Infrastructure.Services;
using EpicShop.Core.Modules.Category.Models;
using EpicShop.Core.Modules.Product.Models;
using EpicShop.Core.Modules.Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace EpicShop.Core.Infrastructure.Data
{
    public class EpicShopContext : DbContext
    {
        private readonly IUserManager _userManager;

        public EpicShopContext(DbContextOptions<EpicShopContext> options, IUserManager userManager) : base(options)
        {
            _userManager = userManager;
        }

        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<ShopModel> Shop { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ShopModel>()
                .HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<ProductModel>()
                .HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<CategoryModel>()
                .HasQueryFilter(p => !p.IsDeleted);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            ChangeTracker.Entries().UpdateMetadataOnSave(_userManager);

            return base.SaveChanges();
        }
    }
}