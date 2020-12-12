using System;
namespace PlayMath.API.Dtos
{
    public class ArticleToCreateDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }
        public string WriterId { get; set; }
        public DateTime published { get; set; }
    }
}