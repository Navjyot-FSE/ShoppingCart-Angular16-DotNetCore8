using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Models.EntityFramework
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}