using System;
using PlayMath.API.Models;

namespace PlayMath.API.Dtos
{
    public class ArticleToReturnDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
        public DateTime Published { get; set; }
        public string WriterName { get; set; }
        public bool IsApproved { get; set; }
        public ArticleCategory Category { get; set; }

    }
}