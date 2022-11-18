
using Domain.Baskets;
using Domain.Categories;
using Domain.Orders;
using Domain.Payments;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<CategoryItem> CategoryItems { get; set; }
        DbSet<CategoryItemImage> CategoryItemImages { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        DbSet<Domain.Orders.Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<UserAddress> UserAddresses { get; set; }
        DbSet<Payment> Payments { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
