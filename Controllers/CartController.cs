using Microsoft.AspNetCore.Mvc;
using quanao.Models;
using quanao.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<List<Cart>> Get() =>
            await _cartService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> Get(string id)
        {
            var cart = await _cartService.GetAsync(id);
            if (cart is null) return NotFound();
            return cart;
        }

        [HttpGet("byNameUser/{nameUser}")]
        public async Task<ActionResult<Cart>> GetNameUser(string nameUser)
        {
            var cart = await _cartService.GetAsyncByNameUser(nameUser);
            if (cart is null) return NotFound();
            return cart;
        }

        [HttpPost]
        public async Task<ActionResult<Cart>> Post(Cart cart)
        {
            await _cartService.CreateAsync(cart);
            return CreatedAtAction(nameof(Get), new { id = cart.Id }, cart);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Cart cart)
        {
            await _cartService.UpdateAsync(id, cart);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _cartService.RemoveAsync(id);
            return NoContent();
        }
    }
}
