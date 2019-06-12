using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArticlesAppXamarin.Models;

namespace ArticlesAppXamarin.Data
{
    public class ArticleManager
    {
        IRestService restService;

        public ArticleManager(IRestService restService)
        {
            this.restService = restService;
        }

        public Task<List<ArticleViewModel>>GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task<bool> LoginAsync(LoginModel loginModel)
        {
            return restService.AuthorizeAsync(loginModel);
        }
    }
}
