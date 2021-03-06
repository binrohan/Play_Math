using System;
using System.Collections.Generic;

namespace PlayMath.API.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PostDate { get; set; }
        public int Viewed { get; set; }
        public bool IsSolved { get; set; }
        public bool IsDeleted { get; set; }
        public ArticleCategory Category { get; set; }
        public User QuestionBy { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}