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
    public class CommentController : ControllerBase {
        private readonly IPlayMathRepository _repo;
        private readonly IMapper _mapper;
        public CommentController (IPlayMathRepository repo, IMapper mapper) {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentToCreateDto commentToCreate)
        {
            var comment = _mapper.Map<Comment>(commentToCreate);

            comment.article = await _repo.GetArticleAsync(commentToCreate.ArticleId);
            comment.Commenter = await _repo.GetUserAsync(commentToCreate.CommenterId);

            _repo.Add(comment);

            if(await _repo.SaveAll())
                return Ok(comment);

            throw new Exception ("Comment failed to post");
        }

        [HttpGet("{articleId}")]
        public async Task<IActionResult> GetComments(int articleId)
        {
            var commentsFromRepo = await _repo.GetCommentsAsync(articleId);
            
            var comments = _mapper.Map<IEnumerable<CommentsToReturnDto>>(commentsFromRepo);

            return Ok(comments);
        }
    }
}