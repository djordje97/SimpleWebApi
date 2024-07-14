using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Models;
using SimpleWebApi.Services;

namespace SimpleWebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var product = _productService.GetById(id);
            if (product is null)
            {
                return BadRequest($"Product with id: {id} does not exits.");
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            var newProduct = _productService.Create(product);
            return Ok(newProduct);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] Product product)
        {
            var productFromDb = _productService.GetById(id);
            if (productFromDb is null)
            {
                return BadRequest($"Product with id: {id} does not exits.");
            }

            var updatedProduct = _productService.Update(product);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var product = _productService.GetById(id);
            if (product is null)
            {
                return BadRequest($"Product with id: {id} does not exits.");
            }
            _productService.Delete(product);
            return NoContent();
        }
    }
}
