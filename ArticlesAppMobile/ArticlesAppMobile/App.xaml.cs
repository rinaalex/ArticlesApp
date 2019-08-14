using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArticlesAppMobile.UI.Pages.Accounts;
using ArticlesAppMobile.BL.ViewModels.Accounts;

namespace ArticlesAppMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage
            {
                //BindingContext = new 
            });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
