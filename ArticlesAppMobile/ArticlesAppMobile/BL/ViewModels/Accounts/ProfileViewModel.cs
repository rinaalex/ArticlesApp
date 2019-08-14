using System.Windows.Input;
using Xamarin.Forms;

using ArticlesAppMobile.UI.Pages.Accounts;
using ArticlesAppMobile.UI.Pages.Articles;
using ArticlesAppMobile.UI.Pages.Reviews;

namespace ArticlesAppMobile.BL.ViewModels.Accounts
{
    public class ProfileViewModel: BaseViewModel
    {
        public ICommand EditProfileCommand { get; set; }
        public ICommand ShowMyArticlesCommand { get; set; }
        public ICommand ShowMyReviewsCommand { get; set; }

        public ProfileViewModel()
        {
            EditProfileCommand = new Command(EditProfile);
            ShowMyArticlesCommand = new Command(ShowMyArticles);
            ShowMyReviewsCommand = new Command(ShowMyReviews);
        }

        public async void EditProfile()
        {
            EditProfilePage editProfilePage = new EditProfilePage();
            await Navigation.PushAsync(editProfilePage);
        }

        public async void ShowMyArticles()
        {
            MyArticlesPage myArticlesPage = new MyArticlesPage();
            await Navigation.PushAsync(myArticlesPage);
        }

        public async void ShowMyReviews()
        {
            MyReviewsPage myReviewsPage = new MyReviewsPage();
            await Navigation.PushAsync(myReviewsPage);
        }
    }
}
