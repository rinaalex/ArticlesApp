using System.Collections.Generic;
using System.Linq;

namespace ArticlesApp.ViewModels.Reviews.QueryObjects
{
    public enum ReviewOrderByOptions
    {
        Simple=0,
        ByPublicationDate,
        ByPublicationDateDecs,
        ByNumStars,
        ByNumStarsDesc
    }

    /// <summary>
    /// Выполняет сортировку ReviewViewModel
    /// </summary>
    public static class ReviewListSort
    {
        /// <summary>
        /// Содержит сопоставление ключей сортировки
        /// </summary>
        public static Dictionary<string, ReviewOrderByOptions> OrderDictionary = new Dictionary<string, ReviewOrderByOptions>();

        static ReviewListSort()
        {
            OrderDictionary.Add("none", ReviewOrderByOptions.Simple);
            OrderDictionary.Add("date", ReviewOrderByOptions.ByPublicationDate);
            OrderDictionary.Add("-date", ReviewOrderByOptions.ByPublicationDateDecs);
            OrderDictionary.Add("stars", ReviewOrderByOptions.ByNumStars);
            OrderDictionary.Add("-stars", ReviewOrderByOptions.ByNumStarsDesc);
        }

        public static IEnumerable<ReviewViewModel>OrderReviewsBy(this IEnumerable<ReviewViewModel> reviews, ReviewOrderByOptions orderByOptions)
        {
            switch(orderByOptions)
            {
                case ReviewOrderByOptions.ByPublicationDate:
                    return reviews.OrderBy(r => r.PublicationDate);
                case ReviewOrderByOptions.ByPublicationDateDecs:
                    return reviews.OrderByDescending(r => r.PublicationDate);
                case ReviewOrderByOptions.ByNumStars:
                    return reviews.OrderBy(r => r.NumStars);
                case ReviewOrderByOptions.ByNumStarsDesc:
                    return reviews.OrderByDescending(r => r.NumStars);
                default: case ReviewOrderByOptions.Simple:
                    return reviews.OrderBy(r => r.Id);
            }
        }
    }
}
