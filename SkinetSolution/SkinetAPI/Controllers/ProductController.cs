using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace SkinetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Products> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRep;
        private readonly IGenericRepository<ProductType> _productType;

        public  ProductController(IGenericRepository<Products> productRepo,
            IGenericRepository<ProductBrand> productBrandRep, IGenericRepository<ProductType> productType)
        {
            _productRepo = productRepo;
            _productBrandRep = productBrandRep;
            _productType = productType;
        }
         
        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<IReadOnlyList<Products>>> GetProducts()
        {
            //
            var specification = new ProductWithTypesAndBrandsSpecification();

             var products = await _productRepo.ListAsync(specification);
             return Ok(products);
        }

        [HttpGet]
        [Route("GetProductsById")]
        public async Task<ActionResult<Products>> GetProductsById(int PId)
        {
            var specification = new ProductWithTypesAndBrandsSpecification(PId); //the second constructor
            
            return await _productRepo.GetEntityWithSpec(specification);
        }

        ////////////////
        [HttpGet]
        [Route("GetProducTypes")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProducTypes()
        {
            var types = await _productType.ListAllAsync();
            return Ok(types);
        }

        [HttpGet]
        [Route("GetProductBrands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var brands = await _productBrandRep.ListAllAsync();
            return Ok(brands);
        }
    }
}
