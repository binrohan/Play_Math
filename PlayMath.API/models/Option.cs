namespace PlayMath.API.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public QuizQuestion Question { get; set; }
    }
}