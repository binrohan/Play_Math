namespace PlayMath.API.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
        public ArticleCategory Category { get; set; }
    }
}