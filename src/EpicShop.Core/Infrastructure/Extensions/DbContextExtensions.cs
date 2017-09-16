using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EpicShop.Core.Infrastructure.Extensions
{
    public static class DbContextExtensions
    {
        public static void UpdateMetadataOnSave(this IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
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
        }
    }
}
