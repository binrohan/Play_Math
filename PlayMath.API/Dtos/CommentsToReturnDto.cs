using System;

namespace PlayMath.API.Dtos
{
    public class CommentsToReturnDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }
    }
}