using System.Windows.Input;
using Xamarin.Forms;

using ArticlesAppMobile.UI.Pages.Reviews;

namespace ArticlesAppMobile.BL.ViewModels.Reviews
{
    public class MyReviewsViewModel: BaseViewModel
    {
        public ICommand ShowReviewCommand { get; set; }
        public ICommand EditReviewCommand { get; set; }

        public MyReviewsViewModel()
        {
            ShowReviewCommand = new Command(ShowReview);
            EditReviewCommand = new Command(EditReview);
        }

        public async void ShowReview()
        {
            ReviewPage reviewPage = new ReviewPage();
            await Navigation.PushAsync(reviewPage);
        }

        public async void EditReview()
        {
            EditReviewPage editReviewPage = new EditReviewPage();
            await Navigation.PushAsync(editReviewPage);
        }
    }
}
