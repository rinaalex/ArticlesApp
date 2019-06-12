using Xamarin.Forms;

namespace ArticlesAppXamarin
{
    public static class Constants
    {
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? @"http://192.168.0.37:5000" : @"https://localhost:5000";
        public static string ArticleItemsUrl = BaseAddress + "/api/articles/";
        public static string LoginUrl = BaseAddress + "/api/accounts/login/";
    }
}
