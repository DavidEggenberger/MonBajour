using DTOs.Share;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Share;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        private List<ShareDTO> shares;
        public ShareController(ShareContainer shares)
        {
            this.shares = shares.Shares;
        }

        [HttpGet]
        public List<ShareDTO> GetShares()
        {
            return this.shares;
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateShare([FromBody] ShareDTO shareDTO)
        {
            this.shares.Add(new ShareDTO
            {
                Messages = shareDTO.Messages,
                SenderUserName = User.Identity.Name,
                UserNamesUpvoted = new List<string>(),
                SentTime = DateTime.Now,
                Type = shareDTO.Type
            });

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public ActionResult DeleteShare([FromRoute] string shareId)
        {
            var share = shares.FirstOrDefault(s => s.Id == new Guid(shareId));
            if(share == null)
            {
                return Ok();
            }
            else
            {
                this.shares.Remove(share);
            }
            return Ok();
        }

        [HttpPost("upvote")]
        [Authorize]
        public ActionResult Upvote([FromRoute] string shareId)
        {
            var share = shares.FirstOrDefault(s => s.Id == new Guid(shareId));
            if (share == null)
            {
                return Ok();
            }
            else
            {
                if (share.UserNamesUpvoted.Contains(HttpContext.User.Identity.Name) is false)
                {
                    share.UserNamesUpvoted.Add(HttpContext.User.Identity.Name);
                }
            }
            return Ok();
        }

        [HttpPost("downvote")]
        [Authorize]
        public ActionResult Downvote([FromRoute] string shareId)
        {
            var share = shares.FirstOrDefault(s => s.Id == new Guid(shareId));
            if (share == null)
            {
                return Ok();
            }
            else
            {
                if (share.UserNamesUpvoted.Contains(HttpContext.User.Identity.Name))
                {
                    share.UserNamesUpvoted.Remove(HttpContext.User.Identity.Name);
                }
            }
            return Ok();
        }
    }
}
