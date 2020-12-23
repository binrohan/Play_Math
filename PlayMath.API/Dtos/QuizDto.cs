using System.Collections.Generic;

namespace PlayMath.API.Dtos
{
    public class QuizDto
    {
        public QuizDto()
        {   
            Options = new List<OptionDto>();
        }
        public string Question { get; set; }
        public IList<OptionDto> Options { get; set; }
    }

    public class OptionDto
    {
        public string Answer { get; set; }
        public bool isCorrect { get; set; }
    }

    public class QuestionDto
    {
        public string Question { get; set; }
    }

    public class QuizQusetionsIdDto
    {
        ICollection<int> QuizIds;
    }
}

// 0: {answer: "A", isCorrect: false}
// 1: {answer: "B", isCorrect: false}
// 2: {answer: "C", isCorrect: true}
// 3: {answer: "D", isCorrect: false}
// length: 4
// __proto__: Array(0)
// question: "new question"