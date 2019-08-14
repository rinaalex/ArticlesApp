using System.Windows.Input;
using Xamarin.Forms;
using ArticlesAppMobile.UI.Pages.Accounts;
using ArticlesAppMobile.UI.Pages.Articles;
using ArticlesAppMobile.UI.Pages.Authors;

namespace ArticlesAppMobile.BL.ViewModels.MainMenu
{
    public class MainMenuViewModel: BaseViewModel
    {
        public ICommand ShowArticlesCommand { get; set; }
        public ICommand ShowAuthorsCommand { get; set; }
        public ICommand ShowProfileCommand { get; set; }

        public MainMenuViewModel()
        {
            ShowArticlesCommand = new Command(ShowArticles);
            ShowAuthorsCommand = new Command(ShowAuthors);
            ShowProfileCommand = new Command(ShowProfile);
        }

        public async void ShowArticles()
        {
            ArticlesListPage articlesListPage = new ArticlesListPage();
            await Navigation.PushAsync(articlesListPage);
        }

        public async void ShowAuthors()
        {
            AuthorsListPage authorsListPage = new AuthorsListPage();
            await Navigation.PushAsync(authorsListPage);
        }

        public async void ShowProfile()
        {
            ProfilePage profilePage = new ProfilePage();
            await Navigation.PushAsync(profilePage);
        }
    }
}
