using ECommerce.WebUI.DTOs.Discount.Coupons;

namespace ECommerce.WebUI.Services.DiscountServices.CouponServices
{
    public class CouponServices(HttpClient _client) : ICouponServices
    {
        public async Task CreateAsync(CreateCouponDto createCouponDto)
        {
            await _client.PostAsJsonAsync("coupons", createCouponDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("coupons/"+id);
        }

        public async Task<List<ResultCouponDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultCouponDto>>("coupons");
        }

        public async Task<ResultCouponDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<ResultCouponDto>("coupons/"+id);
        }

        public async Task<ResultCouponDto> GetCouponByCodeAsycn(string code)
        {
            return await _client.GetFromJsonAsync<ResultCouponDto>("coupons/byCode/" + code);
        }

        public async Task UpdateAsync(UpdateCouponDto updateCouponDto)
        {
            await _client.PutAsJsonAsync("coupons", updateCouponDto);
        }
    }
}
