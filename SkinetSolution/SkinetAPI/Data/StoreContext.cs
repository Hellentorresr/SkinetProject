using Microsoft.EntityFrameworkCore;
using SkinetAPI.Entities;

namespace SkinetAPI.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }

    }
}
