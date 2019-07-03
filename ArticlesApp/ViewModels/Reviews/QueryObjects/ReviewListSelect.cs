using System.Collections.Generic;
using System.Linq;
using ArticlesApp.Model;

namespace ArticlesApp.ViewModels.Reviews.QueryObjects
{
    /// <summary>
    /// Выполняет преобразование Review в ReviewViewModel
    /// </summary>
    public static class ReviewListSelect
    {
        public static IEnumerable<ReviewViewModel> MaptoViewModel(this IEnumerable<Review> reviews)
        {
            return reviews.Select(p => p.MapToViewModel());
        }

        public static ReviewViewModel MapToViewModel(this Review review)
        {
            return new ReviewViewModel
            {
                Id = review.Id,
                ArticleName = review.Article.Title,
                Content = review.Content,
                NumStars = review.NumStars,
                AuthorName = review.Author.Login,
                PublicationDate = review.PublicationDate
            };
        }
    }
}
