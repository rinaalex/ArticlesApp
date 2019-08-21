using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Refit;
using ArticlesApp.DAL.DataObjects;

namespace ArticlesApp.DAL.DataServices.Online
{
    public class AccountDataService: BaseOnlineDataService
    {
        private readonly IAccountDataService _accountDataService;

        public AccountDataService():base()
        {
            _accountDataService = RestService.For<IAccountDataService>(HttpClient);
        }

        public async Task<AuthResultObject> Authorize(LoginObject loginObject)
        {
            try
            {
                return await _accountDataService.Authorize(loginObject).ConfigureAwait(false);
            }
            catch(ValidationApiException ex)
            {
                var content = ex.Content.ToString();
                return null;
            }
            catch(ApiException ex)
            {
                var content = ex.GetContentAs<Dictionary<string, string>>();
                return null;
            }
        }

        public async Task<HttpResponseMessage> Register(LoginObject loginObject)
        {
            try
            {
                return await _accountDataService.Register(loginObject).ConfigureAwait(false);
            }
            catch(ApiException ex)
            {
                var content = ex.GetContentAs<Dictionary<string, string>>();
                return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.SeeOther};
            }
        }
    }
}
