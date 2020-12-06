using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<ArticleCategory>> GetCategories()
        {
            var categories = await _context.ArticleCategories.ToListAsync();

            return categories;
        }

        public async Task<ArticleCategory> GetCategory(int id)
        {
            return await _context.ArticleCategories.FirstOrDefaultAsync(c => c.Id == id);
        }
        
    }
}