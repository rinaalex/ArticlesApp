using System;
using System.Windows.Input;
using Xamarin.Forms;

using ArticlesAppMobile.UI.Pages.Reviews;

namespace ArticlesAppMobile.BL.ViewModels.Reviews
{
    public class ReviewViewModel: BaseViewModel
    {
        public ICommand EditReviewCommand { get; set; }

        public ReviewViewModel()
        {
            EditReviewCommand = new Command(EditReview);
        }

        public async void EditReview()
        {
            EditReviewPage editReviewPage = new EditReviewPage();
            await Navigation.PushAsync(editReviewPage);
        }
    }
}
