using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ArticlesAppXamarin.Models;

namespace ArticlesAppXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        public async void OnSendButtonClick(object sender, EventArgs e)
        {
            bool result = await App.ArticleManager.LoginAsync((LoginModel)this.BindingContext);
            if(result)
            {
                await Navigation.PopAsync();
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "Authorization failed", "Cancel");
            }
        }
    }
}