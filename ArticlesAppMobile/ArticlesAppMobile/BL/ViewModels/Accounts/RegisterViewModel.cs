using Xamarin.Forms;
using System.Windows.Input;
using ArticlesAppMobile.UI.Pages.MainMenu;

namespace ArticlesAppMobile.BL.ViewModels.Accounts
{
    public class RegisterViewModel: BaseViewModel
    {
        public ICommand SubmitCommand { get; private set; }

        public RegisterViewModel()
        {
            SubmitCommand = new Command(Submit);
        }

        public async void Submit()
        {
            MainMenuPage mainMenuPage = new MainMenuPage();
            await Navigation.PushAsync(mainMenuPage);
        }
    }
}
