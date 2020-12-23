using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayMath.API.Data;
using PlayMath.API.Dtos;
using PlayMath.API.Models;

namespace PlayMath.API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class QuizController : ControllerBase {
        private readonly IMapper _mapper;
        private readonly IPlayMathRepository _repo;
        public QuizController (IPlayMathRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddQuiz(QuizDto quiz)
        {
            var questionToAdd = new QuizQuestion();
            questionToAdd.Question = quiz.Question;

            _repo.Add(questionToAdd);

            if(await _repo.SaveAll())
            {   
                foreach (var option in quiz.Options)
                {
                    var optionToAdd = new Option();
                    optionToAdd.Answer = option.Answer;
                    optionToAdd.IsCorrect = option.isCorrect;
                    
                    optionToAdd.Question = await _repo.GetQuizQuestionAsync(questionToAdd.Id);

                    _repo.Add(optionToAdd);
                    await _repo.SaveAll();
                }

                return Ok(quiz);
            }

            throw new Exception("Question failed to add");
        }

        [HttpGet]
        public async Task<IActionResult> RequestQuiz()
        {
            var quizQuestions = await _repo.GetQuizQuestionsAsync();

            var quizQusetionsId = new List<int>();

            foreach (var quiz in quizQuestions)
            {
                quizQusetionsId.Add(quiz.Id);
            }

            return Ok(quizQusetionsId);
        }

        [HttpGet("quiz/{id}")]
        public async Task<IActionResult> GetQuiz(int id)
        {
            var quiz = await _repo.GetQuizQuestionAsync(id);

            return Ok(quiz);
        }

    }
}

