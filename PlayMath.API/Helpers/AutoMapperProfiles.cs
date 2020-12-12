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
            CreateMap<Article, ArticleToReturnDto>()
                .ForMember(dest => dest.WriterName, opt => 
                    opt.MapFrom(src => src.Writer.UserName))
                .ForMember(dest => dest.Category, opt => 
                    opt.MapFrom(src => src.Category.Category));
            CreateMap<ArticleToUpdateDto, Article>();
                    
            // Category Mapper
            CreateMap<ArticleCategory, CategoriesToReturnDto>();

            // Comment Mapper
            CreateMap<CommentToCreateDto, Comment>();
            CreateMap<Comment, CommentsToReturnDto>()
                .ForMember(dest => dest.Commenter, opt =>
                    opt.MapFrom(src => src.Commenter.UserName));
        }
    }
}