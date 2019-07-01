using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ArticlesApp.Interfaces;
using ArticlesApp.Model;
using ArticlesApp.ViewModels;
using ArticlesApp.ViewModels.QueryObjects;

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
            return ArticlesContext.Articles.Include(p=>p.Author).Include(p=>p.Reviews).MapToViewModel();
        }

        public ArticleViewModel GetArticleViewModel(int id)
        {
            var article = this.GetById(id);
            if(article!=null)
            {
                ArticlesContext.Entry(article).Reference(a => a.Author).Load();
                ArticlesContext.Entry(article).Collection(a => a.Reviews).Load();
                return article.MapToViewModel();
            }
            return null;
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
