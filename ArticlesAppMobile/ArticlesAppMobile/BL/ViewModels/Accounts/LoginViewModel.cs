using System.Windows.Input;
using Xamarin.Forms;
using ArticlesAppMobile.UI.Pages.MainMenu;
using ArticlesAppMobile.UI.Pages.Accounts;
using ArticlesApp.DAL.DataServices;
using ArticlesApp.DAL.DataObjects;
using ArticlesApp.DAL.DataServices.Online;

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
            HasError = false;
            LastError = string.Empty;

            var result = await DataServices.Account.Authorize(LoginModel);

            if (result!=null)
            {
                Application.Current.Properties["token"] = result.Token;
                Application.Current.Properties["userId"] = result.UserId;
                DataServices.Articles = new ArticlesDataService(result.Token);
                DataServices.Authors = new AuthorsDataService(result.Token);
                DataServices.Reviews = new ReviewsDataService(result.Token);
                MainMenuPage mainMenuPage = new MainMenuPage();
                await Navigation.PushAsync(mainMenuPage);
            }        
            else
            {
                HasError = true;
                LastError = "Error";
            }
        }

        public async void Registration()
        {
            RegisterPage registerPage = new RegisterPage();
            await Navigation.PushAsync(registerPage);
        }
    }
}
