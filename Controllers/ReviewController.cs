using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using quanao.Models;
using quanao.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<List<Review>> Get() =>
            await _reviewService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> Get(string id)
        {
            var review = await _reviewService.GetAsync(id);
            if (review is null) return NotFound();
            return review;
        }

        [HttpPost]
        public async Task<ActionResult<Review>> Post(string username, string review, string idPro, string like)
        {
            if(username.IsNullOrEmpty() || review.IsNullOrEmpty()){
                return BadRequest("Usernam and review are required");
            }
            Review userReview = new Review{
                nameUser = username,
                review = review,
                idPro = idPro,
                like = "0",
            };
            await _reviewService.CreateAsync(userReview);
            return CreatedAtAction(nameof(Get), new { id = userReview.Id }, userReview);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Review review)
        {
            await _reviewService.UpdateAsync(id, review);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _reviewService.RemoveAsync(id);
            return NoContent();
        }
    }
}
