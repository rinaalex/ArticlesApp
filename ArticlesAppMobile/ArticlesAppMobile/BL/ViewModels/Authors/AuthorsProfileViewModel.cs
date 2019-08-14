using System.Windows.Input;
using Xamarin.Forms;

using ArticlesAppMobile.UI.Pages.Articles;

namespace ArticlesAppMobile.BL.ViewModels.Authors
{
    public class AuthorsProfileViewModel: BaseViewModel
    {
        public string Username { get; set; }
        public int NumOfArticles { get; set; }
        public float Raiting { get; set; }

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
