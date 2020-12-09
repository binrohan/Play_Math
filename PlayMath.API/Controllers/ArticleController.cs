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

            _repo.Add(newArticle);

            if(await _repo.SaveAll())
            {
                return Ok();
            }

            throw new Exception("Article failed to add");

        }

        [HttpGet]
        public async Task<IActionResult> GetArticles([FromQuery]ArticleParams articleParams)
        {
            int pageSize = articleParams.PageSize;
            int pageIndex = articleParams.PageIndex;

            var articles = await _repo.GetArticlesAsync(articleParams);

            return Ok(new {articles, articleParams.Length});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var article = await _repo.GetArticleAsync(id);
            
            return Ok(article);
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