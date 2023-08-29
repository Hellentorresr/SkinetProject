using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SkinetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public  ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
             var products = await _repo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetProductsById")]
        public async Task<ActionResult<Products>> GetProductsById(int PId)
        {
            var product = await _repo.GetProductByIdAsync(PId);
            if (product is null) return NotFound();

            return product;
        }
    }
}
