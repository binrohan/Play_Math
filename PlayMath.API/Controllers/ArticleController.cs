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
    public class ArticleController : ControllerBase {
        private readonly IPlayMathRepository _repo;
        private readonly IMapper _mapper;
        public ArticleController (IPlayMathRepository repo, IMapper mapper) {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(ArticleToCreateDto articleToCreate)
        {

            var newArticle = _mapper.Map<Article>(articleToCreate);
            
            newArticle.Category = await _repo.GetCategoryAsync(articleToCreate.CategoryId);
            newArticle.Writer = await _repo.GetUserAsync(articleToCreate.WriterId);
            
            _repo.Add(newArticle);

            if(await _repo.SaveAll())
            {
                return Ok(newArticle);
            }

            throw new Exception("Article failed to add");

        }

        [HttpGet]
        public async Task<IActionResult> GetArticles([FromQuery]ArticleParams articleParams)
        {
            int pageSize = articleParams.PageSize;
            int pageIndex = articleParams.PageIndex;

            var articlesFromRepo = await _repo.GetArticlesAsync(articleParams);

            var articles = _mapper.Map<IEnumerable<ArticleToReturnDto>>(articlesFromRepo);

            return Ok(new {articles, articleParams.Length});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var article = await _repo.GetArticleAsync(id);
            
            var articleToReturn = _mapper.Map<ArticleToReturnDto>(article);

            
            return Ok(articleToReturn);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, ArticleToUpdateDto articleToUpdate)
        {
            var article = await _repo.GetArticleAsync(id);

            if(!article.Writer.UserName.Equals(articleToUpdate.WriterName))
                return BadRequest("You are not permitted");

            article.Category = await _repo.GetCategoryAsync(articleToUpdate.categoryId);

            _mapper.Map(articleToUpdate, article);

            

            if(await _repo.SaveAll())
            {
                return Ok();
            }

            throw new Exception("Article failed to update");
        }

        [HttpPost("delete/{id}/{uid}")]
        public async Task<IActionResult> DeleteArticle(int id, string uid)
        {
            var article = await _repo.GetArticleAsync(id);

            if(!article.Writer.Id.Equals(uid))
                return BadRequest("You are not permitted");

            article.IsDeleted = true;

            if(await _repo.SaveAll())
            {
                return Ok();
            }

            throw new Exception("Article failed to update");
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categoriesFromRepo = await _repo.GetCategoriesAsync();

            var categoriesToReturn = _mapper.Map<IEnumerable<CategoriesToReturnDto>>(categoriesFromRepo);

            return Ok(categoriesToReturn);
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _repo.GetCategoryAsync(id);

            return Ok(category);
        }
    }
}