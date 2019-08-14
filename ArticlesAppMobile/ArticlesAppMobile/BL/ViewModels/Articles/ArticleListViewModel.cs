using System.Windows.Input;
using Xamarin.Forms;
using ArticlesAppMobile.UI.Pages.Articles;

namespace ArticlesAppMobile.BL.ViewModels.Articles
{
    public class ArticleListViewModel: BaseViewModel
    {
        public ICommand AddArticleCommand { get; set; }
        public ICommand ShowArticleCommand { get; set; }

        public ArticleListViewModel ()
        {
            AddArticleCommand = new Command(AddArticle);
            ShowArticleCommand = new Command(ShowArticle);
        }

        public async void AddArticle()
        {
            // Добавить передачу ид статьи
            AddArticlePage addArticlePage = new AddArticlePage();
            await Navigation.PushAsync(addArticlePage);
        }

        public async void ShowArticle()
        {
            // Добавить передачу ид статьи
            ArticlePage articlePage = new ArticlePage();
            await Navigation.PushAsync(articlePage);
        }
    }
}
