using System.Windows.Input;
using Xamarin.Forms;
using ArticlesAppMobile.UI.Pages.MainMenu;
using ArticlesAppMobile.UI.Pages.Accounts;
using ArticlesApp.DAL.DataServices;
using ArticlesApp.DAL.DataObjects;

namespace ArticlesAppMobile.BL.ViewModels.Accounts
{
    public class LoginViewModel: BaseViewModel
    {      
        public LoginObject LoginModel
        {
            get => Get<LoginObject>();
            set => Set(value);
        }

        public ICommand SubmitCommand { get; private set; }
        public ICommand RegistrationCommand { get; private set; }

        public LoginViewModel()
        {
            LoginModel = new LoginObject();
            SubmitCommand = new Command(Submit);
            RegistrationCommand = new Command(Registration);
        }

        public async void Submit()
        {         
            var result = await DataServices.Account.Authorize(LoginModel);

            if (result!=null)
            {
                MainMenuPage mainMenuPage = new MainMenuPage();
                await Navigation.PushAsync(mainMenuPage);
            }                      
        }

        public async void Registration()
        {
            RegisterPage registerPage = new RegisterPage();
            await Navigation.PushAsync(registerPage);
        }
    }
}
