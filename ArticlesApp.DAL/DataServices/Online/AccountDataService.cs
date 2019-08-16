using System.Threading.Tasks;
using Refit;
using ArticlesApp.DAL.DataObjects;

namespace ArticlesApp.DAL.DataServices.Online
{
    public class AccountDataService: BaseOnlineDataService
    {
        private readonly IAccountDataService _accountDataService;

        public AccountDataService():base()
        {
            _accountDataService = RestService.For<IAccountDataService>(Constants.BaseAddress);
        }

        public async Task<AuthResultObject> Authorize(LoginObject loginObject)
        {
            return await _accountDataService.Authorize(loginObject).ConfigureAwait(false);
        }
    }
}
