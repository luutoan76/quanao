using Microsoft.AspNetCore.Mvc;
using quanao.Models;
using quanao.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using FirebaseAdmin.Messaging;


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
            try
            {
                //Update the order in the database
                await _orderService.UpdateAsync(id, order);

                //Prepare notification data
                var message = new Message
                {
                    Token = "dL4bWuMKSzG6hDdPMkhBOX:APA91bHJo0hO0SoejPf5lGEbc4JNQT24bkkbM_Qhh76qn1ZhRcH94aGpAC7GPxsmbYD0gXcajtscRf-Fc7gt_CsvAM_5stcFTKpttgPZS7nu9iQPDjvpqv4", 
                    // Replace with the device token associated with the user
                    Notification = new Notification
                    {
                        Title = $"Order Updated {order.username}",
                        Body = $"Your order with ID {id} has been updated to status: {order.status}"
                    },
                    Data = new Dictionary<string, string>
                    {
                        { "orderId", id },
                        { "status", order.status },
                        { "username", order.username },
                    }
                };

                //Send the notification
                string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

                // Return success response
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _orderService.RemoveAsync(id);
            return NoContent();
        }
    }
}
