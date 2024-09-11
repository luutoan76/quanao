using Microsoft.AspNetCore.Mvc;
using quanao.Models;
using quanao.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _catgoryService;

        public CategoryController(CategoryService categoryService)
        {
            _catgoryService = categoryService;
        }

        [HttpGet]
        public async Task<List<Category>> Get() =>
            await _catgoryService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(string id)
        {
            var category = await _catgoryService.GetAsync(id);
            if (category is null) return NotFound();
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post(Category category)
        {
            await _catgoryService.CreateAsync(category);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Category category)
        {
            await _catgoryService.UpdateAsync(id, category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _catgoryService.RemoveAsync(id);
            return NoContent();
        }
    }
}
