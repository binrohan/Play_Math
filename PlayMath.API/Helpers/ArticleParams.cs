namespace PlayMath.API.Helpers
{
    public class ArticleParams
    {
        public int CategoryBy { get; set; }
        public string Filter { get; set; }
        public string ByUserId { get; set; }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int Length { get; set; }
    }
}