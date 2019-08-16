using System.Threading.Tasks;
using Refit;
using ArticlesApp.DAL.DataObjects;

namespace ArticlesApp.DAL.DataServices
{
    public interface IAccountDataService
    {
        [Post("/accounts/token")]
        Task<AuthResultObject> Authorize(LoginObject loginObject);
        //Task<RequestResult> Register(RegisterObject registerObject);
        //Task<RequestResult> GetProfile(ProfileObject profileObject);
    }
}
