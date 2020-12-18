using System;

namespace PlayMath.API.Dtos
{
    public class QuestionToCreateDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string QuestionerId { get; set; }
        public int CategoryId { get; set; }
        public DateTime PostDate { get; set; }
    }
}