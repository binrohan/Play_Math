using System.Collections.Generic;
using System.Threading.Tasks;
using PlayMath.API.Helpers;
using PlayMath.API.Models;

namespace PlayMath.API.Data
{
    public interface IPlayMathRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();

         //Article
         Task<IEnumerable<ArticleCategory>> GetCategoriesAsync();
         Task<ArticleCategory> GetCategoryAsync(int id);
         Task<IEnumerable<Article>> GetArticlesAsync(ArticleParams articleParams);
         Task<Article> GetArticleAsync(int id);

         // Comment
         Task<IEnumerable<Comment>> GetCommentsAsync(int articleId);
         
         // User
         Task<User> GetUserAsync(string id); 
         Task<IEnumerable<User>> GetUsersAsync(UserParams userParams);  

         // Question 
         Task<IEnumerable<Question>> GetQuestionsAsync(QuestionParams articleParams);
         Task<Question> GetQuestionAsync(int id);

         // Answer 
         Task<IEnumerable<Answer>> GetAnswersAsync(int id, AnswerParams answerParams);
         Task<Answer> GetAnswerAsync(int id);

         // Quiz
         Task<QuizQuestion> GetQuizQuestionAsync(int id);

    }
}