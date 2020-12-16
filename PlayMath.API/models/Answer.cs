namespace PlayMath.API.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public bool IsBestAnswer { get; set; }
        public User AnsweredBy { get; set; }
        public Question Question { get; set; }
    }
}