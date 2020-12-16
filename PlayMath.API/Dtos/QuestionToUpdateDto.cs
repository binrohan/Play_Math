namespace PlayMath.API.Dtos
{
    public class QuestionToUpdateDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int MyProperty { get; set; }
        public string Questioner { get; set; }
        public int CategoryId { get; set; }
        public bool IsSolved { get; set; }
    }
}