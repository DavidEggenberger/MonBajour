using AutoMapper;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.BaselAPI;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaselAPIDataController : ControllerBase
    {
        private readonly BaselAPIDataBucket baselAPIDataBucket;
        private readonly IMapper mapper;
        public BaselAPIDataController(BaselAPIDataBucket baselAPIDataBucket, IMapper mapper)
        {
            this.baselAPIDataBucket = baselAPIDataBucket;
            this.mapper = mapper;
        }

        [HttpGet]
        public BaselAPIDataBucketDTO Get()
        {
            return mapper.Map<BaselAPIDataBucketDTO>(baselAPIDataBucket);
        }
    }
}
