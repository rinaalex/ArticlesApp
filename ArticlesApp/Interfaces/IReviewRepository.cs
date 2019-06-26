using System.Collections.Generic;
using ArticlesApp.Model;
using ArticlesApp.ViewModels;

namespace ArticlesApp.Interfaces
{
    public interface IReviewRepository: IRepository<Review>
    {
        ReviewViewModel GetReviewViewModel(int id);
        IEnumerable<ReviewViewModel> GetReviewsViewModels(int articleId);
    }
}
