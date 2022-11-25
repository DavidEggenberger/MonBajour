using AutoMapper;
using DTOs;
using WebAPI.BaselAPI;

namespace WebAPI.Mappings
{
    public class BaselAPIDataBucketMappings : Profile
    {
        public BaselAPIDataBucketMappings()
        {
            CreateMap<BaselAPIDataBucket, BaselAPIDataBucketDTO>();
        }
    }
}
