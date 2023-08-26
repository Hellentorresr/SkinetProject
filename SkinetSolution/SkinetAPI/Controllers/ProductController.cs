using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkinetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("GetProducts")]
        public string GetProducts()
        {
            return $"this will be a product";
        }
    }
}
