using System.Collections.Generic;
using ArticlesApp.Model;
using ArticlesApp.ViewModels;

namespace ArticlesApp.Interfaces
{
    public interface IArticleRepository: IRepository<Article>
    {
        Article GetArticleWithReviewes(int id);
        IEnumerable<ArticleViewModel> GetArticlesViewModels();
        ArticleViewModel GetArticleViewModel(int id);
    }
}
