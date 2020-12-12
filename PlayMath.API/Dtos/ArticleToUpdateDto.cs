namespace PlayMath.API.Dtos
{
    public class ArticleToUpdateDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
        public string WriterName { get; set; }
        public int categoryId { get; set; }

    }
}