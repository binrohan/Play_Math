using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayMath.API.Data;
using PlayMath.API.Dtos;
using PlayMath.API.Helpers;
using PlayMath.API.Models;

namespace PlayMath.API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class QuestionController : ControllerBase {
        private readonly IPlayMathRepository _repo;
        private readonly IMapper _mapper;
        public QuestionController (IPlayMathRepository repo, IMapper mapper) {
            _mapper = mapper;
            _repo = repo;
        }


        [HttpPost]
        public async Task<IActionResult> AddQuestion(QuestionToCreateDto questionToCreate)
        {

            var newquestion = _mapper.Map<Question>(questionToCreate);
            
            newquestion.Category = await _repo.GetCategoryAsync(questionToCreate.CategoryId);
            newquestion.QuestionBy = await _repo.GetUserAsync(questionToCreate.QuestionerId);
            
            _repo.Add(newquestion);

            if(await _repo.SaveAll())
            {
                return Ok(newquestion);
            }

            throw new Exception("Question failed to add");

        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions([FromQuery]QuestionParams questionParams)
        {
            int pageSize = questionParams.PageSize;
            int pageIndex = questionParams.PageIndex;

            var questionsFromRepo = await _repo.GetQuestionsAsync(questionParams);

            var questions = _mapper.Map<IEnumerable<QuestionToReturnDto>>(questionsFromRepo);

            return Ok(new {questions, questionParams.Length});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var question = await _repo.GetQuestionAsync(id);
            
            var questionToReturn = _mapper.Map<QuestionToReturnDto>(question);

            
            return Ok(questionToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, QuestionToUpdateDto questionToUpdate)
        {
            var question = await _repo.GetQuestionAsync(id);

            var user = await _repo.GetUserAsync(questionToUpdate.Questioner);

            if(!question.QuestionBy.UserName.Equals(user.UserName))
                return BadRequest("You are not permitted");

            
            question.Category = await _repo.GetCategoryAsync(questionToUpdate.CategoryId);

            _mapper.Map(questionToUpdate, question);

            

            if(await _repo.SaveAll())
            {
                return Ok(question);
            }

            throw new Exception("Question failed to update");
        }

        [HttpPut("delete/{id}/{uid}")]
        public async Task<IActionResult> DeleteQuestion(int id, string uid)
        {
            var question = await _repo.GetQuestionAsync(id);

            if(!question.QuestionBy.Id.Equals(uid))
                return BadRequest("You are not permitted");

            question.IsDeleted = true;

            if(await _repo.SaveAll())
            {
                return Ok(question);
            }

            throw new Exception("Question failed to update");
        }

        [HttpPut("view/{id}")]
        public async Task<IActionResult> ViewQuestion(int id)
        {
            var question = await _repo.GetQuestionAsync(id);

            question.Viewed ++;

            if(await _repo.SaveAll())
            {
                return Ok(question);
            }

            throw new Exception("Question failed to update");
        }
    }
}