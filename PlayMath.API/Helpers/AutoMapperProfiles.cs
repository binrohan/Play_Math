using AutoMapper;
using PlayMath.API.Dtos;
using PlayMath.API.Models;

namespace PlayMath.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Auth Mapper
            CreateMap<User, UserForDetailedDto>();
            CreateMap<UserForRegisterDto, User>();
        }
    }
}