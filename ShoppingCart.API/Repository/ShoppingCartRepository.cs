using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ShoppingCart.Models.EntityFramework;

namespace ShoppingCart.Repository
{
    public class ShoppingCartRepository : Repository<Product>, IShoppingCartRepository
    {
        public ShoppingCartRepository(ShoppingCartDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}