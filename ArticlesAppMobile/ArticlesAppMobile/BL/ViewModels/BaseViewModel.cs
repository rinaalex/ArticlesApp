using System;
using ArticlesAppMobile.Helpers;

namespace ArticlesAppMobile.BL.ViewModels
{
    public class BaseViewModel: Bindable, IDisposable
    {
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
