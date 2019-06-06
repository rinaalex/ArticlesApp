using System.Collections.Generic;
using System.Linq;
using ArticlesApp.Interfaces;
using ArticlesApp.Model;
using ArticlesApp.ViewModels;
using ArticlesApp.ViewModels.QueryObjects;
using Microsoft.EntityFrameworkCore;

namespace ArticlesApp.Repositories
{
    public class ArticleRepository: Repository<Article>, IArticleRepository
    {
        public ArticleRepository(ArticlesContext context)
            :base(context)
        {
        }

        public Article GetArticleWithReviewes(int id)
        {
            return ArticlesContext.Articles.Include(p => p.Reviews).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<ArticleViewModel>GetArticlesViewModels()
        {
            return ArticlesContext.Articles.MapToViewModel();
        }

        public ArticleViewModel GetArticleViewModel(int id)
        {
            var article = this.Get(id);
            return article.MapToViewModel();
        }
                
        public ArticlesContext ArticlesContext
        {
            get
            {
                return context as ArticlesContext;
            }
        }        
    }
}
