using System.Collections.Generic;
using System.Linq;
using ArticlesApp.Model;

namespace ArticlesApp.ViewModels.Authors.QueryObjects
{
    /// <summary>
    /// Выполняет преобразование Author в AuthorViewModel
    /// </summary>
    public static class AuthorListSelect
    {
        public static IEnumerable<AuthorViewModel>MapToViewModel(this IEnumerable<Author> authors)
        {
            return authors.Select(p => p.MapToViewModel());
        }

        public static AuthorViewModel MapToViewModel(this Author author)
        {
            return new AuthorViewModel
            {
                Username = author.Login,
                NumOfArticles = author.Articles.Count,
                Raiting = author.Articles.Count ==0 ? 0 : Raiting(author)
            };
        }

        private static float Raiting(Author author)
        {
            float numStars=0;
            int count = 0;
            foreach(Article article in author.Articles)
            {
                foreach(Review review in article.Reviews)
                {
                    numStars += review.NumStars;
                    count++;
                }
            }
            return numStars / count;            
        }
    }
}
