using System.Windows.Input;
using Xamarin.Forms;
using ArticlesAppMobile.UI.Pages.Articles;

namespace ArticlesAppMobile.BL.ViewModels.Articles
{
    public class AddArticleViewModel: BaseViewModel
    {
        public ICommand SaveArticleCommand { get; set; }

        public AddArticleViewModel()
        {
            SaveArticleCommand = new Command(SaveArticle);
        }

        public async void SaveArticle()
        {
            // Добавить передачу ид новой статьи
            ArticlePage articlePage = new ArticlePage();
            await Navigation.PushAsync(articlePage);
        }
    }
}
