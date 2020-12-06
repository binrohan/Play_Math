using System.Collections.Generic;

namespace PlayMath.API.Models
{
    public class ArticleCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}