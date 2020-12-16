using System;
using PlayMath.API.Models;

namespace PlayMath.API.Dtos
{
    public class QuestionToReturnDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PostDate { get; set; }
        public int Viewed { get; set; }
        public bool IsSolved { get; set; }
        public bool IsDeleted { get; set; }

        public string CategoryName { get; set; }
        public string Questioner { get; set; }

        public ArticleCategory Category { get; set; }
    }
}