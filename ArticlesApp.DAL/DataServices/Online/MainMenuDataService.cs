using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using ArticlesApp.DAL.DataObjects;

namespace ArticlesApp.DAL.DataServices.Online
{
    public class MainMenuDataService: BaseOnlineDataService
    {
        private  IMainMenuDataService _mainMenuDataService;

        public MainMenuDataService(string token=""):base()
        {
            _mainMenuDataService = RestService.For<IMainMenuDataService>(Constants.BaseAddress, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(token)
            });
        }

        public async Task<List<ArticleObject>> GetArticlesList()
        {
            return await _mainMenuDataService.GetArticlesList();
        }
    }
}
