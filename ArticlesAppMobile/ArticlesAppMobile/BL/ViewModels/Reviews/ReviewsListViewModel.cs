using System.Windows.Input;
using System.Collections.Generic;
using Xamarin.Forms;
using ArticlesApp.DAL.DataObjects;
using ArticlesApp.DAL.DataServices;
using ArticlesAppMobile.UI.Pages.Reviews;

namespace ArticlesAppMobile.BL.ViewModels.Reviews
{
    public class ReviewsListViewModel: BaseViewModel
    {
        public List<ReviewObject> ReviewsList
        {
            get => Get<List<ReviewObject>>();
            set => Set(value);
        }

        public ReviewObject Review
        {
            get => Get<ReviewObject>();
            set
            {
                Set(value);
                if (value != null)
                    ShowReview();
            }
        }

        public ICommand ShowReviewCommand { get; set; }

        public ReviewsListViewModel(int articleId)
        {
            ShowReviewCommand = new Command(ShowReview);
            LoadData(articleId);
        }

        async void LoadData(int articleId)
        {
            ReviewsList = await DataServices.Reviews.GetReviewsByArticle(articleId);
            if (ReviewsList==null)
            {
                HasError = true;
                LastError = "Error";
            }
        }

        public async void ShowReview()
        {
            ReviewPage reviewPage = new ReviewPage(Review.Id);
            await Navigation.PushAsync(reviewPage);
        }
    }
}
