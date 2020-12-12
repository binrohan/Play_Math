using System;
using System.Collections.Generic;

namespace PlayMath.API.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
        public DateTime Published { get; set; }
        public User Writer { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }
        public ArticleCategory Category { get; set; }

    }
}