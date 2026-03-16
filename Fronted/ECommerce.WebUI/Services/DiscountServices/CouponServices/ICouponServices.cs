using ECommerce.WebUI.DTOs.Discount.Coupons;

namespace ECommerce.WebUI.Services.DiscountServices.CouponServices
{
    public interface ICouponServices
    {
        Task<ResultCouponDto> GetCouponByCodeAsycn(string code);
        Task<List<ResultCouponDto>> GetAllAsync();
        Task<ResultCouponDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCouponDto createCouponDto);
        Task UpdateAsync(UpdateCouponDto updateCouponDto);
        Task DeleteAsync(int id);
    }
}
