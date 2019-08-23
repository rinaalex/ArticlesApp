using Xamarin.Forms;
using System.Windows.Input;
using ArticlesAppMobile.UI.Pages.MainMenu;
using ArticlesApp.DAL.DataServices;
using ArticlesApp.DAL.DataObjects;

namespace ArticlesAppMobile.BL.ViewModels.Accounts
{
    public class RegisterViewModel: BaseViewModel
    {
        public ICommand SubmitCommand { get; private set; }

        public LoginObject LoginObject
        {
            get => Get<LoginObject>();
            set => Set(value);
        }
                
        public RegisterViewModel()
        {
            HasError = false;
            LoginObject = new LoginObject();
            SubmitCommand = new Command(Submit);
        }

        public async void Submit()
        {
            HasError = false;
            LastError = string.Empty;

            var result = await DataServices.Account.Register(LoginObject);

            if(result.IsSuccessStatusCode)
            {
                var authResult = await DataServices.Account.Authorize(LoginObject);
                if(authResult!=null)
                {
                    Application.Current.Properties["token"] = authResult.Token;
                    MainMenuPage mainMenuPage = new MainMenuPage();
                    await Navigation.PushAsync(mainMenuPage);
                }                
            }     
            else
            {               
                HasError = true;
                LastError = "Error";
            }
        }
    }
}
