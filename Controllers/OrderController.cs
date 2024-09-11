using Microsoft.AspNetCore.Mvc;
using quanao.Models;
using quanao.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<List<Order>> Get() =>
            await _orderService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(string id)
        {
            var order = await _orderService.GetAsync(id);
            if (order is null) return NotFound();
            return order;
        }

        [HttpGet("getUser/{username}")]
        public async Task<ActionResult<List<Order>>> GetByUsername(string username)
        {
            var order = await _orderService.GetAsyncByName(username);
            if (order is null) return NotFound();
            return order;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post(Order order)
        {
            await _orderService.CreateAsync(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Order order)
        {
            await _orderService.UpdateAsync(id, order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _orderService.RemoveAsync(id);
            return NoContent();
        }
    }
}
