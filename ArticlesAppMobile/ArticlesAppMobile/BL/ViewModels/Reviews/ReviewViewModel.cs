using System.Windows.Input;
using Xamarin.Forms;
using ArticlesApp.DAL.DataObjects;
using ArticlesApp.DAL.DataServices;
using ArticlesAppMobile.UI.Pages.Reviews;

namespace ArticlesAppMobile.BL.ViewModels.Reviews
{
    public class ReviewViewModel: BaseViewModel
    {
        public ReviewObject Review
        {
            get => Get<ReviewObject>();
            set => Set(value);
        }

        public ICommand EditReviewCommand { get; set; }

        public ReviewViewModel(int reviewId)
        {
            EditReviewCommand = new Command(EditReview);
            //Review = new ReviewObject();
            LoadData(reviewId);
        }

        async void LoadData(int reviewId)
        {
            Review = await DataServices.Reviews.GetReview(reviewId);
            if(Review==null)
            {
                HasError = true;
                LastError = "Error";
            }
        }

        public async void EditReview()
        {
            EditReviewPage editReviewPage = new EditReviewPage(Review.Id);
            await Navigation.PushAsync(editReviewPage);
        }
    }
}
