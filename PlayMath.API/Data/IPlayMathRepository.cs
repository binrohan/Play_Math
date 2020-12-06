using System.Collections.Generic;
using System.Threading.Tasks;
using PlayMath.API.Models;

namespace PlayMath.API.Data
{
    public interface IPlayMathRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();

         //Article
         Task<IEnumerable<ArticleCategory>> GetCategories();
         Task<ArticleCategory> GetCategory(int id);
    }
}