using System.Windows.Input;
using Xamarin.Forms;
using ArticlesAppMobile.UI.Pages.Articles;
using ArticlesApp.DAL.DataObjects;
using ArticlesApp.DAL.DataServices;

namespace ArticlesAppMobile.BL.ViewModels.Articles
{
    public class AddArticleViewModel: BaseViewModel
    {
        public ArticleObject Article
        {
            get => Get<ArticleObject>();
            set => Set(value);
        }

        public ICommand SaveArticleCommand { get; set; }

        public AddArticleViewModel()
        {
            Article = new ArticleObject();
            SaveArticleCommand = new Command(SaveArticle);
        }

        public async void SaveArticle()
        {
            ArticleObject newArticle = await DataServices.Articles.CreateArticle(Article);
            if(newArticle!=null)
            {
                ArticlePage articlePage = new ArticlePage(newArticle.Id);
                await Navigation.PushAsync(articlePage);
            }
            else
            {
                HasError = true;
                LastError = "Error";
            }
        }
    }
}
