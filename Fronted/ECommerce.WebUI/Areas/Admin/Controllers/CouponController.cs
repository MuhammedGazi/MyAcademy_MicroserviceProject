using ECommerce.WebUI.Services.DiscountServices.CouponServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CouponController(ICouponServices _services) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var coupons = await _services.GetAllAsync();
            return View(coupons);
        }
    }
}
