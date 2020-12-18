using System;

namespace PlayMath.API.Dtos
{
    public class AnswerToCreateDto
    {
        public string AnswererId { get; set; }
        public int QuestionId { get; set; }
        public  string Body { get; set; }
    }
}