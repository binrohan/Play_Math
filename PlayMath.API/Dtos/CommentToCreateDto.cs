using System;
using PlayMath.API.Models;

namespace PlayMath.API.Dtos
{
    public class CommentToCreateDto
    {
        public int ArticleId { get; set; }
        public string CommenterId { get; set; } 
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }
    }
}