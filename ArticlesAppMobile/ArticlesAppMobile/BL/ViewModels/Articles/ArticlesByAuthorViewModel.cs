using System.Windows.Input;
using Xamarin.Forms;

using ArticlesAppMobile.UI.Pages.Articles;

namespace ArticlesAppMobile.BL.ViewModels.Articles
{
    public class ArticlesByAuthorViewModel: BaseViewModel
    {
        public ICommand ShowArticleCommand { get;set; }

        public ArticlesByAuthorViewModel()
        {
            ShowArticleCommand = new Command(ShowArticle);
        }

        public async void ShowArticle()
        {
            ArticlePage articlePage = new ArticlePage();
            Navigation.PushAsync(articlePage);
        }
    }
}
