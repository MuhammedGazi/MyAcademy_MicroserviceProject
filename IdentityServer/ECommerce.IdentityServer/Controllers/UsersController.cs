using ECommerce.IdentityServer.DTOs;
using ECommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                LastName = model.LastName,
                FirstName = model.FirstName,
            };
            var result=await _userManager.CreateAsync(user,model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("kullanıcı kaydı başarılı");
        } 
    }
}
