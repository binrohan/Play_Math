using System;
using PlayMath.API.Models;

namespace PlayMath.API.Dtos
{
    public class CommentsToReturnDto
    {
        public int Id { get; set; }
        public string Commenter { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }
    }
}