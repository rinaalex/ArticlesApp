using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ArticlesAppXamarin.Data;
using ArticlesAppXamarin.Views;

namespace ArticlesAppXamarin
{
    public partial class App : Application
    {
        static ArticleManager articleManager;

        public static ArticleManager ArticleManager
        {
            get
            {
                if (articleManager == null)
                {
                    articleManager = new ArticleManager(new RestService());
                }
                return articleManager;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new AuthorizationPage
            {
                BindingContext = new ArticlesAppXamarin.Models.LoginModel()
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
