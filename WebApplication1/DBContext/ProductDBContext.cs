using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DBContext
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
    }
}
