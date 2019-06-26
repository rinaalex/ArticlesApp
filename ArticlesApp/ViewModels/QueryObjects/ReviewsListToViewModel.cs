using System.Collections.Generic;
using System.Linq;
using ArticlesApp.Model;

namespace ArticlesApp.ViewModels.QueryObjects
{
    public static class ReviewsListToViewModel
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
                Content = review.Content,
                NumStars = review.NumStars,
                AuthorName = review.Author.Login,
                PublicationDate = review.PublicationDate
            };
        }
    }
}
