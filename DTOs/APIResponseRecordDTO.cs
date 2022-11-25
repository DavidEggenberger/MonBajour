using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class APIResponseRecordDTO<T>
    {
        public string datasetid { get; set; }
        public string recordid { get; set; }
        public T fields { get; set; }
        public DateTime record_timestamp { get; set; }
    }
}
