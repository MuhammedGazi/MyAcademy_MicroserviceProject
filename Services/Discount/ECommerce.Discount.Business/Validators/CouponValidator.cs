using ECommerce.Discount.Entity.Entities;
using FluentValidation;

namespace ECommerce.Discount.Business.Validators
{
    public class CouponValidator : AbstractValidator<Coupon>
    {
        public CouponValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code boş bırakılamaz");
            RuleFor(x => x.DiscountRate).NotEmpty().WithMessage("DiscountRate boş bırakılamaz");
            RuleFor(x => x.ExpireDate).NotEmpty().WithMessage("ExpireDate boş bırakılamaz");
        }
    }
}
