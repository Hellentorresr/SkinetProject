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
        public async Task<ActionResult<IReadOnlyList<Products>>> GetProducts()
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

        ////////////////
        [HttpGet]
        [Route("GetProducTypes")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProducTypes()
        {
            var types = await _repo.GetProducTypeAsync();
            return Ok(types);
        }

        [HttpGet]
        [Route("GetProductBrands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var brands = await _repo.GetBrandsAsync();
            return Ok(brands);
        }
    }
}
