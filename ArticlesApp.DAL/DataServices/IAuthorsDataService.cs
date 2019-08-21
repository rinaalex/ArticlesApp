using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using ArticlesApp.DAL.DataObjects;

namespace ArticlesApp.DAL.DataServices
{
    [Headers("Authorization: Bearer")]
    public interface IAuthorsDataService
    {        
        [Get("/authors/")]
        Task<List<AuthorObject>> GetAuthors([AliasAs("sort")] string sortOrder="asc");

        [Get("/authors/{id}")]
        Task<AuthorObject> GetAuthor([AliasAs("id")] int authorId);
    }
}
