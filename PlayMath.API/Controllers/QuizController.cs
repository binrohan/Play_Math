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
            var questionToAdd = _mapper.Map<QuizQuestion>(quiz);

            _repo.Add(questionToAdd);

            if(await _repo.SaveAll())
            {   
                foreach (var option in quiz.Options)
                {
                    var optionToAdd = _mapper.Map<Option>(option);
                    optionToAdd.Question = await _repo.GetQuizQuestionAsync(questionToAdd.Id);

                    _repo.Add(optionToAdd);
                    await _repo.SaveAll();
                }

                return Ok();
            }


            

            return Ok(new {questionToAdd});
        }

    }
}

