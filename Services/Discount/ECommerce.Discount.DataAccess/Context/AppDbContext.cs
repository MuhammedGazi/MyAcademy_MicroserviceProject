using ECommerce.Discount.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Discount.DataAccess.Context
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Coupon> Coupons { get; set; }
    }
}
