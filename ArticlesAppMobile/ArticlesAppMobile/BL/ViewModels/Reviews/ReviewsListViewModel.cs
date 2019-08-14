using System.Windows.Input;
using Xamarin.Forms;

using ArticlesAppMobile.UI.Pages.Reviews;

namespace ArticlesAppMobile.BL.ViewModels.Reviews
{
    public class ReviewsListViewModel: BaseViewModel
    {
        public ICommand ShowReviewCommand { get; set; }

        public ReviewsListViewModel()
        {
            ShowReviewCommand = new Command(ShowReview);
        }

        public async void ShowReview()
        {
            ReviewPage reviewPage = new ReviewPage();
            await Navigation.PushAsync(reviewPage);
        }
    }
}
