using System.Linq;
using PlayMath.API.Models;

namespace PlayMath.API.Helpers
{
    public static class TQuery
    {
        public static IQueryable<Article> ArticleQuery (ArticleParams articleParams, IQueryable<Article> articles)
        {
            if(!string.IsNullOrEmpty(articleParams.Filter))
            {
                articles = articles.Where(a => a.Title.Contains(articleParams.Filter));
            }

            if(articleParams.CategoryBy != 0)
            {
                articles = articles.Where(a => a.Category.Id == articleParams.CategoryBy);
            }

            articleParams.Length = articles.Count();

            articles = articles.Skip(articleParams.PageIndex*articleParams.PageSize).Take(articleParams.PageSize).Select(a => a);

            return articles;
        }

        public static IQueryable<Question> QuestionQuery (QuestionParams questionParams, IQueryable<Question> questions)
        {
            if(!string.IsNullOrEmpty(questionParams.Filter))
            {
                questions = questions.Where(a => a.Title.Contains(questionParams.Filter));
            }

            if(questionParams.CategoryBy != 0)
            {
                questions = questions.Where(a => a.Category.Id == questionParams.CategoryBy);
            }

            questionParams.Length = questions.Count();

            questions = questions.Skip(questionParams.PageIndex*questionParams.PageSize).Take(questionParams.PageSize).Select(a => a);

            return questions;
        }

        public static IQueryable<Answer> QuestionQuery (AnswerParams questionParams, IQueryable<Answer> questions)
        {
            questionParams.Length = questions.Count();

            questions = questions.Skip(questionParams.PageIndex*questionParams.PageSize).Take(questionParams.PageSize).Select(a => a);

            return questions;
        }

        public static IQueryable<User> UserQuery (UserParams articleParams, IQueryable<User> articles)
        {
            if(!string.IsNullOrEmpty(articleParams.Filter))
            {
                articles = articles.Where(a => a.UserName.Contains(articleParams.Filter));
            }

            articleParams.Length = articles.Count();

            articles = articles.Skip(articleParams.PageIndex*articleParams.PageSize).Take(articleParams.PageSize).Select(a => a);

            return articles;
        }
    }
}