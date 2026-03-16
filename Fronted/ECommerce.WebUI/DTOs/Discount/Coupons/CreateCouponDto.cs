namespace ECommerce.WebUI.DTOs.Discount.Coupons
{
    public record CreateCouponDto
    {
        public string Code { get; init; }
        public int DiscountRate { get; init; }
        public DateTime ExpireDate { get; init; }
    }
}
