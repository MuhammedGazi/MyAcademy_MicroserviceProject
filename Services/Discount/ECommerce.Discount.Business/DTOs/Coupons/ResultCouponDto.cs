namespace ECommerce.Discount.Business.DTOs.Coupons
{
    public record ResultCouponDto
    {
        public int Id { get; init; }
        public string Code { get; init; }
        public int DiscountRate { get; init; }
        public DateTime ExpireDate { get; init; }
    }
}
