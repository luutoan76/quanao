using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quanao.Models;
using quanao.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<Product>> Get() =>
            await _productService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var product = await _productService.GetAsync(id);
            if (product is null) return NotFound();
            return product;
        }

        [HttpGet("Search/{name}")]
        public async Task<ActionResult<List<Product>>> GetByNamePro(string name)
        {
            var product = await _productService.SearchByNameAsync(name);
            if (product.Count == 0) return NotFound();
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            await _productService.CreateAsync(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Product product)
        {
            await _productService.UpdateAsync(id, product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.RemoveAsync(id);
            return NoContent();
        }
    }
}
