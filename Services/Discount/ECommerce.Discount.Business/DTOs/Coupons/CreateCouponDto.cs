namespace ECommerce.Discount.Business.DTOs.Coupons
{
    public record CreateCouponDto
    {
        public string Code { get; init; }
        public int DiscountRate { get; init; }
        public DateTime ExpireDate { get; init; }
    }
}
