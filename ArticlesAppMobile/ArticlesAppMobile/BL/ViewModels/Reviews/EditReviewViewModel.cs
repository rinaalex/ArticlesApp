using System.Windows.Input;
using Xamarin.Forms;
using ArticlesApp.DAL.DataObjects;
using ArticlesApp.DAL.DataServices;

namespace ArticlesAppMobile.BL.ViewModels.Reviews
{
    public class EditReviewViewModel:BaseViewModel
    {
        public ReviewObject Review
        {
            get => Get<ReviewObject>();
            set => Set(value);
        }

        public ICommand SaveReviewCommand { get; set; }

        public EditReviewViewModel(int reviewId)
        {
            SaveReviewCommand = new Command(SaveReview);
            Review = new ReviewObject();
            LoadData(reviewId);
        }

        async void LoadData(int reviewId)
        {
            Review = await DataServices.Reviews.GetReview(reviewId);
            if(Review ==null)
            {
                HasError = true;
                LastError = "Error";
            }
        }

        public async void SaveReview()
        {
            ReviewObject newReview = await DataServices.Reviews.UpdateReview(Review);
            if (newReview != null)
            {
                await Navigation.PopAsync();
            }
            else
            {
                HasError = true;
                LastError = "Error";
            }
        }
    }
}
