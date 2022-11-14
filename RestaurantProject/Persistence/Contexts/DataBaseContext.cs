using Application.Interfaces;
using Domain.Attributes;
using Domain.Baskets;
using Domain.Categories;
using Domain.Orders;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class DataBaseContext : IdentityDbContext<User>, IDatabaseContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> dbContextOptions) : base(dbContextOptions)
        {

        }

         public DbSet<Category> Categories { get; set; }
         public  DbSet<CategoryItem> CategoryItems { get; set; }
         public  DbSet<CategoryItemImage> CategoryItemImages { get; set; }
         public  DbSet<Basket> Baskets { get; set; }
         public  DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems  { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");
            builder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.ProviderKey, p.LoginProvider });
            builder.Entity<IdentityUserToken<string>>().HasKey(p => new { p.UserId, p.LoginProvider });
            builder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
            builder.Entity<User>().Ignore(p => p.NormalizedEmail);

            foreach (var item in builder.Model.GetEntityTypes())
            {
                if (item.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    builder.Entity(item.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                    builder.Entity(item.Name).Property<DateTime?>("UpdateTime").IsRequired(false);
                    builder.Entity(item.Name).Property<DateTime?>("RemoveTime").IsRequired(false);
                }
            }


            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                                .Where(p => p.State == EntityState.Modified ||
                                p.State == EntityState.Added ||
                                p.State == EntityState.Deleted);

            foreach (var item in modifiedEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
                if (entityType != null)
                {
                    var inserted = entityType.FindProperty("InsertTime");
                    var updated = entityType.FindProperty("UpdateTime");
                    var RemoveTime = entityType.FindProperty("RemoveTime");

                    if(item.State == EntityState.Added && inserted != null)
                        item.Property("InsertTime").CurrentValue = DateTime.Now;
                    if (item.State == EntityState.Modified && updated != null)
                        item.Property("UpdateTime").CurrentValue = DateTime.Now;
                    if (item.State == EntityState.Deleted && RemoveTime != null)
                        item.Property("RemoveTime").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();

        }
    }
}
