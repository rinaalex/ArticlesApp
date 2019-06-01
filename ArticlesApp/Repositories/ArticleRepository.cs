using System.Collections.Generic;
using System.Linq;
using ArticlesApp.Interfaces;
using ArticlesApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ArticlesApp.Repositories
{
    public class ArticleRepository: Repository<Article>, IArticleRepository
    {
        public ArticleRepository(ArticlesContext context)
            :base(context)
        {
        }

        public Article GetArticleWithReviews(int id)
        {
            return ArticlesContext.Articles.Include(p => p.Reviews).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Article>GetTopArticles()
        {
            // добавить построение рейтинга
            return ArticlesContext.Articles.ToList();
        }

        public double AverangeRating(int id)
        {
            var article = this.GetArticleWithReviews(id);
            if (article == null || article.Reviews.Count==0)
            {
                return 0;
            }

            double sum = 0;
            foreach(Review review in article.Reviews)
            {
                sum += review.NumStars;
            }
            return sum / article.Reviews.Count();
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
