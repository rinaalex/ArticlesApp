using System.Windows.Input;
using Xamarin.Forms;

using ArticlesAppMobile.UI.Pages.Reviews;

namespace ArticlesAppMobile.BL.ViewModels.Reviews
{
    public class AddReviewViewModel: BaseViewModel
    {
        public ICommand SaveReviewCommand { get; set; }

        public AddReviewViewModel()
        {
            SaveReviewCommand = new Command(SaveReview);
        }

        public async void SaveReview()
        {
            ReviewPage reviewPage = new ReviewPage();
            Navigation.PushAsync(reviewPage);
        }
    }
}
