using Microsoft.AspNetCore.Mvc;
using quanao.Models;
using quanao.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly FavourtieService _favouriteService;

        public FavouriteController(FavourtieService favourtieService)
        {
            _favouriteService = favourtieService;
        }

        [HttpGet]
        public async Task<List<Favourtie>> Get() =>
            await _favouriteService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Favourtie>> Get(string id)
        {
            var favourtie = await _favouriteService.GetAsync(id);
            if (favourtie is null) return NotFound();
            return favourtie;
        }

        [HttpGet("getFav/{username}")]
        public async Task<ActionResult<List<Favourtie>>> GetFavUser(string username)
        {
            var favourtie = await _favouriteService.GetAsyncByUsername(username);
            if (favourtie is null) return NotFound();
            return favourtie;
        }

        [HttpPost]
        public async Task<ActionResult<Favourtie>> Post(Favourtie favourtie)
        {
            await _favouriteService.CreateAsync(favourtie);
            return CreatedAtAction(nameof(Get), new { id = favourtie.Id }, favourtie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Favourtie favourtie)
        {
            await _favouriteService.UpdateAsync(id, favourtie);
            return NoContent();
        }

        [HttpDelete("{idPro}")]
        public async Task<IActionResult> Delete(string idPro)
        {
            await _favouriteService.RemoveAsync(idPro);
            return NoContent();
        }
    }
}
