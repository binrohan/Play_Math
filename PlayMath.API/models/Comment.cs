using System;
using System.Collections.Generic;

namespace PlayMath.API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Article article { get; set; }
        public User Commenter { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }
    }
}