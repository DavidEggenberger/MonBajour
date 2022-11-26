using DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public ActionResult<BFFUserInfoDTO> GetCurrentUser([FromServices] UserInfoDTOBucket bucket)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return BFFUserInfoDTO.Anonymous;
            }

            var userInfoDTO = bucket.UserInfos.FirstOrDefault(s => s.UserName == User.Identity.Name);

            var claims = User.Claims.Select(claim => new ClaimValueDTO { Type = claim.Type, Value = claim.Value }).ToList();

            if (userInfoDTO != null)
            {
                claims.Add(new ClaimValueDTO() { Type = "address", Value = userInfoDTO.Address });
            }

            return new BFFUserInfoDTO()
            {
                Claims = claims
            };
        }

        [HttpPost("address/{address}")]
        public async Task<ActionResult> SaveAddress([FromRoute] string address, [FromServices] UserInfoDTOBucket bucket)
        {
            var userInfoDTO = bucket.UserInfos.FirstOrDefault(s => s.UserName == User.Identity.Name);
            if (userInfoDTO == null)
            {
                bucket.UserInfos.Add(new UserInfoDTO
                {
                    UserName = User.Identity.Name,
                    Address = address
                });
            }
            else
            {
                userInfoDTO.Address = address;
            }

            return Redirect("/");
        }
    }
}
