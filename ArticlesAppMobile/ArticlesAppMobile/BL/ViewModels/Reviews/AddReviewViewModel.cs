using System.Windows.Input;
using Xamarin.Forms;
using ArticlesApp.DAL.DataObjects;
using ArticlesApp.DAL.DataServices;
using ArticlesAppMobile.UI.Pages.Reviews;

namespace ArticlesAppMobile.BL.ViewModels.Reviews
{
    public class AddReviewViewModel: BaseViewModel
    {
        private readonly int articleId;

        public ReviewObject Review
        {
            get => Get<ReviewObject>();
            set => Set(value);
        }

        public ICommand SaveReviewCommand { get; set; }

        public AddReviewViewModel(int articleId)
        {
            SaveReviewCommand = new Command(SaveReview);
            this.articleId = articleId;
            Review = new ReviewObject();
        }

        public async void SaveReview()
        {
            ReviewObject newReview = await DataServices.Reviews.CreateReview(articleId, Review);
            if(newReview!=null)
            {
                ReviewPage reviewPage = new ReviewPage(newReview.Id);
                await Navigation.PushAsync(reviewPage);
            }
            else
            {
                HasError = true;
                LastError = "Error";
            }
        }
    }
}
