using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlayMath.API.Helpers;
using PlayMath.API.Models;

namespace PlayMath.API.Data
{
    public class PlayMathRepository : IPlayMathRepository
    {
        private readonly DataContext _context;
        public PlayMathRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        // Article Category
        public async Task<IEnumerable<ArticleCategory>> GetCategoriesAsync()
        {
            var categories = await _context.ArticleCategories.ToListAsync();

            return categories;
        }

        public async Task<ArticleCategory> GetCategoryAsync(int id)
        {
            return await _context.ArticleCategories.FirstOrDefaultAsync(c => c.Id == id);
        }


        // Article
        public async Task<IEnumerable<Article>> GetArticlesAsync(ArticleParams articleParams)
        {
            // Gotta back for implementing orderby date after another migration
            var articles = _context.Articles
                            .Include(a => a.Category)
                            .AsQueryable();
            
            articles = TQuery.ArticleQuery(articleParams, articles);
            return await articles.ToListAsync();
        }

        public async Task<Article> GetArticleAsync(int id)
        {
            return await _context.Articles.Include(a => a.Category).FirstOrDefaultAsync(a => a.Id == id);
        }
        
    }
}