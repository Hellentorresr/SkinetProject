using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkinetAPI.Data;
using SkinetAPI.Entities;

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

     
    }
}
