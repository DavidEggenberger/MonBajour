using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Share
{
    public class ShareDTO
    {
        public Guid Id { get; set; }
        public string SenderUserName { get; set; }
        public string Messages { get; set; }
        public List<string> UserNamesUpvoted { get; set; }
    }
}
