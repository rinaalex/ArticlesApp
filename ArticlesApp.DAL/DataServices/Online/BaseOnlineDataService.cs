using System;
using System.Collections.Generic;
using System.Text;
using Refit;
using System.Net.Http;

namespace ArticlesApp.DAL.DataServices.Online
{
    public class BaseOnlineDataService
    {
        public HttpClient HttpClient;

        public BaseOnlineDataService()
        {
            HttpClient = new HttpClient(new HttpClientHandler()) { BaseAddress = new Uri(Constants.BaseAddress)};
        }
    }
}
