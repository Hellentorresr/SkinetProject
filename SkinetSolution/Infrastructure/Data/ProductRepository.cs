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
            return await _context.Products.
                 Include(p => p.ProductType).
                   Include(p => p.ProductBrand)
                   .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Products>> GetProductsAsync()
        {
            return await _context.Products.
                Include(p => p.ProductType).
                   Include(p => p.ProductBrand)
                    .ToListAsync();//this method is the one executing the query and getting 
            //the data back from the database
        }


        ///////////////////////////
        public async Task<ProductBrand> GetBrandByIdAsync(int id)
        {
            return  await _context.Brands.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetBrandsAsync()
        {
            return await _context.Brands.ToListAsync();
        }


        public async Task<ProductType> GetProductTypeByIdAsync(int id)
        {
            return await _context.ProductTypes.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProducTypeAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
