using System.Windows.Input;
using System.Collections.Generic;
using Xamarin.Forms;

using ArticlesApp.DAL.DataObjects;
using ArticlesApp.DAL.DataServices;
using ArticlesAppMobile.UI.Pages.Articles;

namespace ArticlesAppMobile.BL.ViewModels.Articles
{
    public class MyArticlesViewModel: BaseViewModel
    {
        public List<ArticleObject> ArticlesList
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
                if (value!=null)
                    ShowArticle();
            }
        }

        public ICommand ShowArticleCommand { get; set; }
        public ICommand EditArticleCommand { get; set; }

        public MyArticlesViewModel()
        {
            ShowArticleCommand = new Command(ShowArticle);
            EditArticleCommand = new Command(EditArticle);
            LoadData();
        }

        async void LoadData()
        {
            int authorId = (int)Application.Current.Properties["userId"];
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

        public async void EditArticle()
        {
            //EditArticlePage editArticlePage = new EditArticlePage();
            //await Navigation.PushAsync(editArticlePage);
        }
    }
}
