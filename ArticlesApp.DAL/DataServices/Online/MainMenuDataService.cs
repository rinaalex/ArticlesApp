using System.Threading.Tasks;
using Refit;

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
    }
}
