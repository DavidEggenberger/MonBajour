using DTOs;
using System.Collections.Generic;

namespace WebAPI
{
    public class UserInfoDTOBucket
    {
        public List<UserInfoDTO> UserInfos { get; set; } = new List<UserInfoDTO>();
    }
}
