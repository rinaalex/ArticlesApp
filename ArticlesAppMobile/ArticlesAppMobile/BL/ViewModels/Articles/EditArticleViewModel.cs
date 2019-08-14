using System.Windows.Input;
using Xamarin.Forms;

using ArticlesAppMobile.UI.Pages.Articles;

namespace ArticlesAppMobile.BL.ViewModels.Articles
{
    public class EditArticleViewModel:BaseViewModel
    {
        public ICommand SaveCommand { get; set; }

        public EditArticleViewModel()
        {
            SaveCommand = new Command(Save);
        }

        public async void Save()
        {
            await Navigation.PopAsync();
        }
    }
}
