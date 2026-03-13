using ECommerce.Discount.Business.DTOs.Coupons;
using ECommerce.Discount.Business.Services.Coupons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CouponsController(ICouponService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coupons = await _service.GetAllAsync();
            return Ok(coupons);
        }
        [HttpGet("byCode/{code}")]
        public async Task<IActionResult> GetAll(string code)
        {
            var coupon = await _service.GetCouponByCodeAsycn(code);
            return Ok(coupon);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var coupon = await _service.GetByIdAsync(id);
            return Ok(coupon);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponDto dto)
        {
            await _service.CreateAsync(dto);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCouponDto dto)
        {
            await _service.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
