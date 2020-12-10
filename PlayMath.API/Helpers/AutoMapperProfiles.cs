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

            // Article Mapper
            CreateMap<ArticleToCreateDto, Article>();
            CreateMap<ArticleCategory, CategoriesToReturnDto>();

            // Comment Mapper
            CreateMap<Comment, CommentsToReturnDto>()
                .ForMember(dest => dest.UserName, opt =>
                    opt.MapFrom(src => src.Commenter.UserName));
        }
    }
}