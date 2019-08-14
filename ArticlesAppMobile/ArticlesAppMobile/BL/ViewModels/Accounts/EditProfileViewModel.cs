using System.Windows.Input;
using Xamarin.Forms;

namespace ArticlesAppMobile.BL.ViewModels.Accounts
{
    public class EditProfileViewModel: BaseViewModel
    {
        public ICommand SaveCommand { get; set; }

        public EditProfileViewModel()
        {
            SaveCommand = new Command(Save);
        }

        public async void Save()
        {
            await Navigation.PopAsync();
        }
    }
}
