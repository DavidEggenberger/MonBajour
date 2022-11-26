using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Share
{
    public class ShareDTO
    {
        public string SenderUserName { get; set; }
        public string Messages { get; set; }
        public int Upvotes { get; set; }
    }
}
