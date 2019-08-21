using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using ArticlesApp.DAL.DataObjects;

namespace ArticlesApp.DAL.DataServices.Online
{
    public class AuthorsDataService: BaseOnlineDataService
    {
        protected readonly IAuthorsDataService _authorsDataService;

        public AuthorsDataService(string token = "") :base()
        {
            _authorsDataService = RestService.For<IAuthorsDataService>(Constants.BaseAddress, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(token)
            });
        }

        public async Task<List<AuthorObject>>GetAuthors(string sortOrder)
        {
            try
            {
                return await _authorsDataService.GetAuthors(sortOrder);
            }
            catch(ApiException ex)
            {
                return null;
            }
        }

        public async Task<AuthorObject> GetAuthor(int authorId)
        {
            try
            {
                return await _authorsDataService.GetAuthor(authorId);
            }
            catch(ApiException ex)
            {
                return null;
            }
        }
    }
}
