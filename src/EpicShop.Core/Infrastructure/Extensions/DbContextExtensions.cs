using System;
using System.Collections.Generic;
using EpicShop.Core.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EpicShop.Core.Infrastructure.Extensions
{
    public static class DbContextExtensions
    {
        public static string CreatedDateTime;
        public static string UpdatedDateTime;
        public static string CreatedBy;
        public static string UpdatedBy;

        public static void UpdateMetadataOnSave(this IEnumerable<EntityEntry> entries, IUserManager userManager)
        {
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(nameof(CreatedDateTime)).CurrentValue = DateTime.UtcNow;
                    entry.Property(nameof(CreatedBy)).CurrentValue = userManager.ResolveUserName();
                }

                entry.Property(nameof(UpdatedDateTime)).CurrentValue = DateTime.UtcNow;
                entry.Property(nameof(UpdatedBy)).CurrentValue = userManager.ResolveUserName();

            }
        }
    }
}
