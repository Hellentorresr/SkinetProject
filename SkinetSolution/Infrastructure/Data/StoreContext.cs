using Core.Entiies;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }

    }
}
