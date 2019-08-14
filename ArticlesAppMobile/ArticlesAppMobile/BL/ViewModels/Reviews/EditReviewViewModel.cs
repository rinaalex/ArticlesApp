using System.Windows.Input;
using Xamarin.Forms;

using ArticlesAppMobile.UI.Pages.Reviews;

namespace ArticlesAppMobile.BL.ViewModels.Reviews
{
    public class EditReviewViewModel:BaseViewModel
    {
        public ICommand SaveReviewCommand { get; set; }

        public EditReviewViewModel()
        {
            SaveReviewCommand = new Command(SaveReview);
        }

        public async void SaveReview()
        {

        }
    }
}
