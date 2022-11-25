using DTOs;
using System.Collections.Generic;

namespace WebAPI.BaselAPI
{
    public class BaselAPIDataBucket
    {
        public IEnumerable<EntsorgungsstelleDTO> Entsorgungsstellen { get; set; }
    }
}
