using Apple.Services.CouponAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace Apple.Services.CouponAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}
