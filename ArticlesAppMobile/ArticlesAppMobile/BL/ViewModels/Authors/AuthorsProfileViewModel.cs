using System.Windows.Input;
using Xamarin.Forms;
using ArticlesApp.DAL.DataObjects;
using ArticlesApp.DAL.DataServices;
using ArticlesAppMobile.UI.Pages.Articles;

namespace ArticlesAppMobile.BL.ViewModels.Authors
{
    public class AuthorsProfileViewModel: BaseViewModel
    {
        public AuthorObject Author
        {
            get => Get<AuthorObject>();
            set => Set(value);
        }

        public ICommand ShowArticlesByAuthorCommand { get; set; }

        public AuthorsProfileViewModel(int authorId)
        {
            ShowArticlesByAuthorCommand = new Command(ShowArticlesByAuthor);
            Author = new AuthorObject();
            LoadData(authorId);
        }

        async void LoadData(int authorId)
        {
            Author = await DataServices.Authors.GetAuthor(authorId);
            if(Author==null)
            {
                HasError = true;
                LastError = "Error";
            }
        }

        public async void ShowArticlesByAuthor()
        {
            ArticlesByAuthorPage articlesByAuthorPage = new ArticlesByAuthorPage(Author.Id);
            await Navigation.PushAsync(articlesByAuthorPage);
        }
    }
}
