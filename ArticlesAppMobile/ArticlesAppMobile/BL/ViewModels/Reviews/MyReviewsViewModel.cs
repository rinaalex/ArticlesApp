using System.Windows.Input;
using System.Collections.Generic;
using Xamarin.Forms;
using ArticlesApp.DAL.DataObjects;
using ArticlesApp.DAL.DataServices;
using ArticlesAppMobile.UI.Pages.Reviews;

namespace ArticlesAppMobile.BL.ViewModels.Reviews
{
    public class MyReviewsViewModel: BaseViewModel
    {
        public List<ReviewObject>ReviewsList
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
        public ICommand EditReviewCommand { get; set; }

        public MyReviewsViewModel()
        {
            ShowReviewCommand = new Command(ShowReview);
            EditReviewCommand = new Command(EditReview);
            LoadData();
        }

        async void LoadData()
        {
            int authorId = int.Parse(Application.Current.Properties["userId"].ToString());
            ReviewsList = await DataServices.Reviews.GetReviewsByAuthor(authorId);
            if(ReviewsList==null)
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

        public async void EditReview()
        {
            EditReviewPage editReviewPage = new EditReviewPage(Review.Id);
            await Navigation.PushAsync(editReviewPage);
        }
    }
}
