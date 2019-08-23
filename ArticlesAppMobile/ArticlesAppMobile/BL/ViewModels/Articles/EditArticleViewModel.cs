using System.Windows.Input;
using Xamarin.Forms;

using ArticlesApp.DAL.DataObjects;
using ArticlesApp.DAL.DataServices;

namespace ArticlesAppMobile.BL.ViewModels.Articles
{
    public class EditArticleViewModel:BaseViewModel
    {
        public ArticleObject Article
        {
            get => Get<ArticleObject>();
            set => Set(value);
        }

        public ICommand SaveCommand { get; set; }

        public EditArticleViewModel(int articleId)
        {
            SaveCommand = new Command(Save);
            LoadData(articleId);
        }

        async void LoadData(int articleId)
        {
            Article = await DataServices.Articles.GetArticle(articleId);
        }

        public async void Save()
        {
            var newArticle = await DataServices.Articles.UpdateArticle(Article);
            if(newArticle!=null)
            {
                await Navigation.PopAsync();
            }            
            else
            {
                HasError = true;
                LastError = "Error";
            }
        }
    }
}
