using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using ArticlesAppMobile.UI.Pages.Articles;
using ArticlesApp.DAL.DataServices;
using ArticlesApp.DAL.DataObjects;

namespace ArticlesAppMobile.BL.ViewModels.Articles
{
    public class ArticleListViewModel : BaseViewModel
    {
        public ArticleObject SelectedArticle
        {
            get => Get<ArticleObject>();
            set
            {
                Set(value);
                if(value!=null)
                    ShowArticle();
            }
        }

        public List<ArticleObject> ArticlesList
        {
            get => Get<List<ArticleObject>>();
            set => Set(value);
        }

        public ICommand AddArticleCommand { get; set; }
        public ICommand ShowArticleCommand { get; set; }

        public ArticleListViewModel()
        {
            AddArticleCommand = new Command(AddArticle);
            ShowArticleCommand = new Command(ShowArticle);

            LoadData();
        }

        public async void LoadData()
        {           
            ArticlesList = await DataServices.Articles.GetArticlesList();
            if (ArticlesList == null)
            {
                HasError = true;
                LastError = "Error";
            }
        }

        public async void AddArticle()
        {
            AddArticlePage addArticlePage = new AddArticlePage();
            await Navigation.PushAsync(addArticlePage);
        }

        public async void ShowArticle()
        {           
            ArticlePage articlePage = new ArticlePage(SelectedArticle.Id);
            await Navigation.PushAsync(articlePage);
        }
    }
}
