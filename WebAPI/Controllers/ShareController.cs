using DTOs.Share;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        private List<ShareDTO> shares;
        public ShareController(List<ShareDTO> shares)
        {
            this.shares = shares;
        }

        [HttpGet]
        public List<ShareDTO> GetShares()
        {
            return this.shares;
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateShare([FromRoute] string message)
        {
            this.shares.Add(new ShareDTO
            {
                Messages = message,
                SenderUserName = User.Identity.Name,
                Upvotes = 0
            });

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public ActionResult DeleteShare([FromRoute] string message)
        {
            this.shares.Add(new ShareDTO
            {
                Messages = message,
                SenderUserName = User.Identity.Name,
                Upvotes = 0
            });

            return Ok();
        }
    }
}
