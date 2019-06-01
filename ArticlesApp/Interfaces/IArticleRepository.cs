using System.Collections.Generic;
using ArticlesApp.Model;

namespace ArticlesApp.Interfaces
{
    public interface IArticleRepository: IRepository<Article>
    {
        Article GetArticleWithReviews(int id);
        IEnumerable<Article> GetTopArticles();
        double AverangeRating(int id);
    }
}
