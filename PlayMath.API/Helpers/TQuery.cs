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
    }
}