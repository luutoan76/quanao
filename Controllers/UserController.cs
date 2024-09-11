using Microsoft.AspNetCore.Mvc;
using quanao.Models;
using quanao.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> Get() =>
            await _userService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var category = await _userService.GetAsync(id);
            if (category is null) return NotFound();
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, User user)
        {
            await _userService.UpdateAsync(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.RemoveAsync(id);
            return NoContent();
        }
    }
}
