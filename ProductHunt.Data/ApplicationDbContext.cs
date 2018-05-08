using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductHunt.Data.Entity;

namespace ProductHunt.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext() : base("DefaultConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(p => p.Entity is BaseEntity && p.State == EntityState.Added || p.State == EntityState.Detached || p.State == EntityState.Deleted || p.State == EntityState.Modified);
            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Detached;
                }
                entity.UpdatedOn = DateTime.Now;
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker.Entries()
             .Where(p => p.Entity is BaseEntity && p.State == EntityState.Added || p.State == EntityState.Detached || p.State == EntityState.Deleted || p.State == EntityState.Modified);
            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Detached;
                }
                entity.UpdatedOn = DateTime.Now;
            }
            return base.SaveChangesAsync();
        }
    }
}
