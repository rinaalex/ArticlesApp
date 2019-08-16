using System.Windows.Input;
using Xamarin.Forms;

using ArticlesAppMobile.UI.Pages.Articles;

namespace ArticlesAppMobile.BL.ViewModels.Authors
{
    public class AuthorsProfileViewModel: BaseViewModel
    {
        public ICommand ShowArticlesByAuthorCommand { get; set; }

        public AuthorsProfileViewModel()
        {
            ShowArticlesByAuthorCommand = new Command(ShowArticlesByAuthor);
        }

        public async void ShowArticlesByAuthor()
        {
            ArticlesByAuthorPage articlesByAuthorPage = new ArticlesByAuthorPage();
            await Navigation.PushAsync(articlesByAuthorPage);
        }
    }
}
