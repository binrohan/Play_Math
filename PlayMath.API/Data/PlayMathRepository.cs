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
                            .Where(a => a.IsDeleted == false)
                            .Include(a => a.Category)
                            .AsQueryable();
            
            articles = TQuery.ArticleQuery(articleParams, articles);

            return await articles.ToListAsync();
        }

        public async Task<Article> GetArticleAsync(int id)
        {
            return await _context.Articles
                .Where(a => a.IsDeleted == false)
                .Include(a => a.Category)
                .Include(a => a.Writer)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        
        // User Repos
        public async Task<User> GetUserAsync(string id)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                .Include(u => u.Articles)
                .Include(u => u.Comments)
                .FirstOrDefaultAsync(u => u.Id == id);
                
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(UserParams userParams)
        {
            var users = _context.Users
                .Include(u => u.Articles)
                .Include(u => u.Comments)
                .Include(u => u.Answers)
                .Include(u => u.Questions)
                .Include(u => u.UserRoles)
                .AsQueryable();
            
            users = TQuery.UserQuery(userParams, users);

            return await users.ToListAsync();

        }

        // Comment Repos
        public async Task<IEnumerable<Comment>> GetCommentsAsync(int articleId)
        {
            var comments = await _context.Comments
                .Include(c => c.Commenter)
                .Where(c => c.article.Id == articleId)
                .ToListAsync();

            return comments;
        }

        // Question Repo
        public async Task<IEnumerable<Question>> GetQuestionsAsync(QuestionParams questionParams)
        {
            // Gotta back for implementing orderby date after another migration
            var questions = _context.Questions
                            .Where(a => a.IsDeleted == false)
                            .Include(a => a.Category)
                            .Include(q => q.QuestionBy)
                            .AsQueryable();
            
            questions = TQuery.QuestionQuery(questionParams, questions);

            return await questions.ToListAsync();
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await _context.Questions
                .Where(a => a.IsDeleted == false)
                .Include(a => a.Category)
                .Include(a => a.QuestionBy)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // Answer Repo
         public async Task<IEnumerable<Answer>> GetAnswersAsync(int id, AnswerParams questionParams)
        {
            // Gotta back for implementing orderby date after another migration
            var answers = _context.Answers
                            .Where(a => a.IsDeleted == false)
                            .Where(a => a.Question.Id == id)
                            .Include(a => a.AnsweredBy)
                            .AsQueryable();
            
            answers = TQuery.QuestionQuery(questionParams, answers);

            return await answers.ToListAsync();
        }

        public async Task<Answer> GetAnswerAsync(int id)
        {
            return await _context.Answers
                .Where(a => a.IsDeleted == false)
                .Include(a => a.AnsweredBy)
                .Include(a => a.Question)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // Others
    }
}