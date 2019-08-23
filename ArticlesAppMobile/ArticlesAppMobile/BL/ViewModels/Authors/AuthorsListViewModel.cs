using System.Windows.Input;
using System.Collections.Generic;
using Xamarin.Forms;
using ArticlesApp.DAL.DataObjects;
using ArticlesApp.DAL.DataServices;
using ArticlesAppMobile.UI.Pages.Authors;

namespace ArticlesAppMobile.BL.ViewModels.Authors
{
    public class AuthorsListViewModel: BaseViewModel
    {
        public List<AuthorObject>AuthorsList
        {
            get => Get<List<AuthorObject>>();
            set => Set(value);
        }

        public AuthorObject Author
        {
            get => Get<AuthorObject>();
            set
            {
                Set(value);
                if (value != null)
                    ShowAuthorsProfile();
            }
        }

        public ICommand ShowAuthorsProfileCommand { get; set; }

        public AuthorsListViewModel()
        {
            ShowAuthorsProfileCommand = new Command(ShowAuthorsProfile);
            LoadData();
        }

        async void LoadData()
        {
            AuthorsList = await DataServices.Authors.GetAuthors();
            if(AuthorsList==null)
            {
                HasError = true;
                LastError = "Error";
            }
        }

        public async void ShowAuthorsProfile()
        {
            AuthorsProfilePage authorsProfilePage = new AuthorsProfilePage(Author.Id);
            await Navigation.PushAsync(authorsProfilePage);
        }
    }
}
