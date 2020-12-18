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
    public class AnswerController : ControllerBase {
        private readonly IPlayMathRepository _repo;
        private readonly IMapper _mapper;
        public AnswerController (IPlayMathRepository repo, IMapper mapper) {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddAnswer(AnswerToCreateDto answerToCreate)
        {

            var answer = _mapper.Map<Answer>(answerToCreate);
            
            
            answer.AnsweredBy = await _repo.GetUserAsync(answerToCreate.AnswererId);
            answer.Question = await _repo.GetQuestionAsync(answerToCreate.QuestionId);
            
            _repo.Add(answer);

            if(await _repo.SaveAll())
            {
                return Ok(answer);
            }

            throw new Exception("answer failed to add");

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswers(int id, [FromQuery]AnswerParams answerParams)
        {
            int pageSize = answerParams.PageSize;
            int pageIndex = answerParams.PageIndex;

            var answersFromRepo = await _repo.GetAnswersAsync(id, answerParams);

            var answers = _mapper.Map<IEnumerable<Answer>>(answersFromRepo);

            return Ok(new {answers, answerParams.Length});
        }

        public async Task<IActionResult> GetAnswer(int id)
        {
            var answer = await _repo.GetAnswerAsync(id);
            
            answer = _mapper.Map<Answer>(answer);

            
            return Ok(answer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnswer(int id, AnswerToUpdateDto answerToUpdate)
        {
            var answer = await _repo.GetAnswerAsync(id);

            var user = await _repo.GetUserAsync(answerToUpdate.AnswererId);

            if(!answer.AnsweredBy.UserName.Equals(user.UserName))
                return BadRequest("You are not permitted");


            _mapper.Map(answerToUpdate, answer);


            if(await _repo.SaveAll())
            {
                return Ok(answer);
            }

            throw new Exception("answer failed to update");
        }

        [HttpPut("best/{id}/{uid}")]
        public async Task<IActionResult> MarkBestAnswer(int id, string uid, AnswerToUpdateDto answerToUpdate)
        {
            var answer = await _repo.GetAnswerAsync(id);

            var question = await _repo.GetQuestionAsync(answerToUpdate.QuestionId);

            answer.IsBestAnswer = !answer.IsBestAnswer;
                
            if(!question.QuestionBy.Id.Equals(uid))
                return BadRequest("You are not permitted");


            _mapper.Map(answerToUpdate, answer);


            if(await _repo.SaveAll())
            {
                return Ok(answer);
            }

            throw new Exception("answer failed to update");
        }

        [HttpPut("delete/{id}/{uid}")]
        public async Task<IActionResult> DeleteAnswer(int id, string uid)
        {
            var answer = await _repo.GetAnswerAsync(id);

            if(!answer.AnsweredBy.Id.Equals(uid))
                return BadRequest("You are not permitted");

            answer.IsDeleted = true;

            if(await _repo.SaveAll())
            {
                return Ok(answer);
            }

            throw new Exception("answer failed to update");
        }

    }
}