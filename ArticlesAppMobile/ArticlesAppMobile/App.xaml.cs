using Xamarin.Forms;
using ArticlesAppMobile.UI.Pages.Accounts;
using ArticlesApp.DAL.DataServices;

namespace ArticlesAppMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DataServices.Init(false);

            MainPage = new NavigationPage(new LoginPage());            
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
