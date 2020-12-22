using System.Collections.Generic;

namespace PlayMath.API.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}