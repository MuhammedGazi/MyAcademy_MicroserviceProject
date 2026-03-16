using ECommerce.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(ICategoryService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetAllAsync();
            return View(categories);
        }
    }
}
