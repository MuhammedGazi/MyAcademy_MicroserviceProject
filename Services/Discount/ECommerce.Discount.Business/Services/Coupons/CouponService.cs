using ECommerce.Discount.Business.DTOs.Coupons;
using ECommerce.Discount.DataAccess.Repositories.CouponsRepositories;
using ECommerce.Discount.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Discount.Business.Services.Coupons
{
    public class CouponService(ICouponsRepository _repository,
                               IValidator<Coupon> _validator) : ICouponService
    {
        public async Task CreateAsync(CreateCouponDto createCouponDto)
        {
            var coupon = createCouponDto.Adapt<Coupon>();
            var result = await _validator.ValidateAsync(coupon);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _repository.CreateAsync(coupon);
        }

        public async Task DeleteAsync(int id)
        {
            var coupon = await _repository.GetByIdAsync(id);
            if (coupon is null)
            {
                throw new ArgumentNullException($"{id} ait Coupon not found");
            }
            await _repository.DeleteAsync(coupon);
        }

        public async Task<List<ResultCouponDto>> GetAllAsync()
        {
            var coupons = await _repository.GetAllAsync();
            return coupons.Adapt<List<ResultCouponDto>>();
        }

        public async Task<ResultCouponDto> GetByIdAsync(int id)
        {
            var coupon = await _repository.GetByIdAsync(id);
            if (coupon is null)
            {
                throw new ArgumentNullException($"{id} ait Coupon not found");
            }
            return coupon.Adapt<ResultCouponDto>();
        }

        public async Task<ResultCouponDto> GetCouponByCodeAsycn(string code)
        {
            var coupon = await _repository.GetQueryable().FirstOrDefaultAsync(x => x.Code == code);
            if (coupon is null)
            {
                throw new ArgumentNullException($"{code} ait Coupon not found");
            }
            return coupon.Adapt<ResultCouponDto>();
        }

        public async Task UpdateAsync(UpdateCouponDto updateCouponDto)
        {
            var coupon = await _repository.GetByIdAsync(updateCouponDto.Id);
            if (coupon is null)
            {
                throw new ArgumentNullException($"{updateCouponDto.Id} ait Coupon not found");
            }
            updateCouponDto.Adapt(coupon);
            await _repository.UpdateAsync(coupon);
        }
    }
}
