using System.Windows.Input;
using System.Collections.Generic;
using Xamarin.Forms;
using ArticlesApp.DAL.DataObjects;
using ArticlesApp.DAL.DataServices;
using ArticlesAppMobile.UI.Pages.Articles;

namespace ArticlesAppMobile.BL.ViewModels.Articles
{
    public class ArticlesByAuthorViewModel: BaseViewModel
    {
        public List<ArticleObject>ArticlesList
        {
            get => Get<List<ArticleObject>>();
            set => Set(value);
        }

        public ArticleObject Article
        {
            get => Get<ArticleObject>();
            set
            {
                Set(value);
                if (value != null)
                    ShowArticle();
            }
        }

        public ICommand ShowArticleCommand { get;set; }

        public ArticlesByAuthorViewModel(int authorId)
        {
            ShowArticleCommand = new Command(ShowArticle);
            LoadData(authorId);
        }

        async void LoadData(int authorId)
        {
            ArticlesList = await DataServices.Articles.GetArticlesByAuthor(authorId);
            if(ArticlesList==null)
            {
                HasError = true;
                LastError = "Error";
            }
        }

        public async void ShowArticle()
        {
            ArticlePage articlePage = new ArticlePage(Article.Id);
            await Navigation.PushAsync(articlePage);
        }
    }
}
