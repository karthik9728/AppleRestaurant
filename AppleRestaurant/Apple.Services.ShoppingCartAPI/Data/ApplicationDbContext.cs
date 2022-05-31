using Apple.Services.ShoppingCartAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace Apple.Services.ShoppingCartAPI.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CardHeader> CartHeaders { get; set; }
        public DbSet<CardDetails> CartDetails { get; set; }
    }
}
