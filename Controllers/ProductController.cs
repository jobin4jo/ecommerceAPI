using ecommerceAPI.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet("list")]
        public async Task<ActionResult> GetAllProductList()
        {
            try
            {
                   var response = await productRepository.GetAllProductList();
                return Ok(response);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
