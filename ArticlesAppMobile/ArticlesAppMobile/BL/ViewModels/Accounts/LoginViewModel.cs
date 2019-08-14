using System.Windows.Input;
using Xamarin.Forms;
using ArticlesAppMobile.UI.Pages.MainMenu;
using ArticlesAppMobile.UI.Pages.Accounts;

namespace ArticlesAppMobile.BL.ViewModels.Accounts
{
    public class LoginViewModel: BaseViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public ICommand SubmitCommand { get; private set; }
        public ICommand RegistrationCommand { get; private set; }

        public LoginViewModel()
        {
            SubmitCommand = new Command(Submit);
            RegistrationCommand = new Command(Registration);
        }

        public async void Submit()
        {
            MainMenuPage mainMenuPage = new MainMenuPage();
            await Navigation.PushAsync(mainMenuPage);
        }

        public async void Registration()
        {
            RegisterPage registerPage = new RegisterPage();
            await Navigation.PushAsync(registerPage);
        }
    }
}
