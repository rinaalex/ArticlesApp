using System;
using Xamarin.Forms;
using ArticlesAppMobile.Helpers;

namespace ArticlesAppMobile.BL.ViewModels
{
    public class BaseViewModel: Bindable, IDisposable
    {
        public INavigation Navigation { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseViewModel()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            //ClearDialogs();
            //CancelNetworkRequests();
        }
    }
}
