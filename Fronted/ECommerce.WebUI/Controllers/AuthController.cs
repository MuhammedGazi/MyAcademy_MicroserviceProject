using ECommerce.WebUI.DTOs.IdentityServer;
using ECommerce.WebUI.Services.IdentityServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class AuthController(IIdentityService _identityService) : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _identityService.LoginAsync(loginDto);
            if (!result)
            {
                ModelState.AddModelError("", "kullanıcı adı yada şifre ahatalı");
                return View();
            }
            return Redirect("/Admin/Category/Index");
        }
    }
}
