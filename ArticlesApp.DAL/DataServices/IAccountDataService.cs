using System.Threading.Tasks;
using System.Net.Http;
using Refit;
using ArticlesApp.DAL.DataObjects;

namespace ArticlesApp.DAL.DataServices
{
    public interface IAccountDataService
    {
        [Post("/accounts/token")]
        Task<AuthResultObject> Authorize(LoginObject loginInfo);

        [Post("/accounts/register")]
        Task<HttpResponseMessage> Register(LoginObject registerInfo);

        //Logout

        //Task<RequestResult> GetProfile(ProfileObject profileObject);
    }
}
