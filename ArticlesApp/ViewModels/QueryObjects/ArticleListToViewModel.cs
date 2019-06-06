using System.Linq;
using System.Collections.Generic;
using ArticlesApp.Model;

namespace ArticlesApp.ViewModels.QueryObjects
{
    public static class ArticleListToViewModel
    {
        public static IEnumerable<ArticleViewModel> MapToViewModel(this IEnumerable<Article> articles)
        {
            return articles.Select(p=>p.MapToViewModel());
        }

        public static ArticleViewModel MapToViewModel(this Article article)
        {
            return new ArticleViewModel
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                PublicationDate = article.PublicationDate,
                AuthorName = article.Author.Login,
                Raiting = article.Reviews.Count == 0 ? 0 : (float)article.Reviews.Sum(q => q.NumStars) / article.Reviews.Count()
            };
        }
    }
}
