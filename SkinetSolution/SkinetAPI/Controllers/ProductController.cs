using Core.Entiies;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//End section 2 update

namespace SkinetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _context;

        public  ProductController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
          return await _context.Products.ToListAsync();
        }

        [HttpGet]
        [Route("GetProductsById")]
        public async Task<ActionResult<Products>> GetProductsById(int PId)
        {
            var product = await _context.Products.FindAsync(PId); // request is made to the store for an entity with the given primary key values and this entity, if found, is attached to the context and returned. If no entity is found in the context or the store, then null is returned.

            if (product is null) return NotFound();
            return product;
        }
    }
}
