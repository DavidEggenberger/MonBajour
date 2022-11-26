using DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Infrastructure;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BFFUserController : ControllerBase
    {
        [HttpGet("login")]
        public ActionResult LoginWithGoogle()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, "Google");
        }

        [Authorize]
        [HttpGet("Logout")]
        public async Task<ActionResult> LogoutCurrentUser()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        [HttpGet("BFFUser")]
        [AllowAnonymous]
        public ActionResult<BFFUserInfoDTO> GetCurrentUser()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return BFFUserInfoDTO.Anonymous;
            }

            return new BFFUserInfoDTO()
            {
                Claims = User.Claims.Select(claim => new ClaimValueDTO { Type = claim.Type, Value = claim.Value }).ToList()
            };
        }
    }
}
