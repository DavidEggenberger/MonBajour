using DTOs.Share;
using System;
using System.Collections.Generic;

namespace WebAPI.Share
{
    public class ShareContainer
    {
        public List<ShareDTO> Shares { get; set; } = new List<ShareDTO>
        {
            new ShareDTO
            {
                Messages = "Der EHC Olten geht mit 1:0 in Führung gegen den EHC Basel",
                SenderUserName = "BaselSport",
                SentTime = DateTime.Now.AddHours(- 2),
                Type = ShareTypeEnum.Sport,
                UserNamesUpvoted = new List<string>{"", ""}
            },
            new ShareDTO
            {
                Messages = "Es gibt eine neue Museumsführung",
                SenderUserName = "Museeumsbehörde Basel",
                SentTime = DateTime.Now.AddHours(- 6),
                Type = ShareTypeEnum.Cultural,
                UserNamesUpvoted = new List<string>{"", "", "", ""}
            }
        };
    }
}
