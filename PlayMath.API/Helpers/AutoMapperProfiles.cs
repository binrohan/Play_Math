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


            // Question Mapper
            CreateMap<QuestionToCreateDto, Question>();
            CreateMap<Question, QuestionToReturnDto>()
                .ForMember(dest => dest.Questioner, opt => 
                    opt.MapFrom(src => src.QuestionBy.UserName))
                .ForMember(dest => dest.CategoryName, opt =>
                    opt.MapFrom(src => src.Category.Category))
                .ForMember(dest => dest.AnswerCount, opt =>
                    opt.MapFrom(src => src.Answers.Count));
            CreateMap<QuestionToUpdateDto, Question>();


            // Answer Mapper
            CreateMap<AnswerToCreateDto, Answer>();
            CreateMap<AnswerToUpdateDto, Answer>();

            CreateMap<UserToUpdateDto, User>();
            CreateMap<User, UserToReturnDto>();

            CreateMap<CategoryToCreate, ArticleCategory>();


            // Quiz
            CreateMap<QuizDto, QuizQuestion>()
                .ForMember(dest => dest.Question, opt => 
                    opt.MapFrom(src => src.Question));
            CreateMap<QuizDto, Option>();
                
        }
    }
}