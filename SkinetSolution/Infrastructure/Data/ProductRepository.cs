using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

//Our repository is going to be interacting with our store context, and then our
//controllers are going to use the repository methods in order to retrieve the data from the db
//with means the repository is abstracting our data access methods away from the controller

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        //constructor, Injecting the StoreContex class
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Products> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Products>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
