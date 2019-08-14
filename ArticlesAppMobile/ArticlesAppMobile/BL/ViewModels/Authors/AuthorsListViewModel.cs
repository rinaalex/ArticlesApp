using System.Windows.Input;
using Xamarin.Forms;

using ArticlesAppMobile.UI.Pages.Authors;

namespace ArticlesAppMobile.BL.ViewModels.Authors
{
    public class AuthorsListViewModel: BaseViewModel
    {
        public ICommand ShowAuthorsProfileCommand { get; set; }

        public AuthorsListViewModel()
        {
            ShowAuthorsProfileCommand = new Command(ShowAuthorsProfile);
        }

        public async void ShowAuthorsProfile()
        {
            AuthorsProfilePage authorsProfilePage = new AuthorsProfilePage();
            await Navigation.PushAsync(authorsProfilePage);
        }
    }
}
