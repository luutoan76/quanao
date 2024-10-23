using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using quanao.Models;
using quanao.Services;

namespace quanao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController:ControllerBase
    {
        private readonly VoucherService _voucherService;

        public VoucherController(VoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        [HttpGet]
        public async Task<List<Voucher>> Get() =>
            await _voucherService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Voucher>> Get(string id)
        {
            var voucher = await _voucherService.GetAsync(id);
            if (voucher is null) return NotFound();
            return voucher;
        }

        [HttpPost]
        public async Task<ActionResult<Voucher>> Post(string nameVoucher, string imgVoucher, string description, string startTime, string endTime, string discount, string amount)
        {
            Voucher voucher = new Voucher{
                nameVoucher = nameVoucher,
                imgVoucher = imgVoucher,
                description = description,
                startTime = startTime,
                endTime = endTime,
                discount = discount,
                amount = amount,
            };
            
            await _voucherService.CreateAsync(voucher);
            return CreatedAtAction(nameof(Get), new { id = voucher.Id }, voucher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id,string nameVoucher, string imgVoucher, string description, string startTime, string endTime, string discount, string amount)
        {
            var exsistVoucher = await _voucherService.GetAsync();
            if(id.IsNullOrEmpty()){
                return BadRequest("ID is a must");
            }
            if(exsistVoucher == null){
                return BadRequest("ID not existted");
            }

            Voucher voucher = new Voucher{
                Id = id,
                nameVoucher = nameVoucher,
                imgVoucher = imgVoucher,
                description = description,
                startTime = startTime,
                endTime = endTime,
                discount = discount,
                amount = amount,
            };
            await _voucherService.UpdateAsync(id, voucher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _voucherService.RemoveAsync(id);
            return NoContent();
        }
    }
}
