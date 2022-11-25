using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class APIResponseRootDTO<T>
    {
        public int nhits { get; set; }
        public List<T> records { get; set; }
    }
}
