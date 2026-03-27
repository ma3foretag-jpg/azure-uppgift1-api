using Azure_uppgift1_API.Data.Entites;
using Azure_uppgift1_API.Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Azure_uppgift1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepo _repo;

        public ProductController(ProductRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            var add = await _repo.AddProduct(product);

            if (add == null)
                return BadRequest("Product kan inte skapa");

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            var delete = await _repo.DeleteProduct(id);

            if (!delete)
                return NotFound("Det finns inte product med den Id");

            return NoContent();
        }
    }
}
