using System.Collections.Generic;
using System.Threading.Tasks;
using ArticlesAppXamarin.Models;

namespace ArticlesAppXamarin.Data
{
    public interface IRestService
    {
        Task<List<ArticleModel>> RefreshDataAsync();
        Task<bool> AuthorizeAsync(LoginModel loginModel);
    }
}
