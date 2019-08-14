using System.Windows.Input;
using Xamarin.Forms;

using ArticlesAppMobile.UI.Pages.Articles;

namespace ArticlesAppMobile.BL.ViewModels.Articles
{
    public class MyArticlesViewModel: BaseViewModel
    {
        public ICommand ShowArticleCommand { get; set; }
        public ICommand EditArticleCommand { get; set; }

        public MyArticlesViewModel()
        {
            ShowArticleCommand = new Command(ShowArticle);
            EditArticleCommand = new Command(EditArticle);
        }

        public async void ShowArticle()
        {
            ArticlePage articlePage = new ArticlePage();
            await Navigation.PushAsync(articlePage);
        }

        public async void EditArticle()
        {
            EditArticlePage editArticlePage = new EditArticlePage();
            await Navigation.PushAsync(editArticlePage);
        }
    }
}
