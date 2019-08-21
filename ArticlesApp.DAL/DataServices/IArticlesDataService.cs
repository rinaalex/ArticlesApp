using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using ArticlesApp.DAL.DataObjects;

namespace ArticlesApp.DAL.DataServices
{
    [Headers("Authorization: Bearer")]
    public interface IArticlesDataService
    {
        [Get("/articles/")]        
        Task<List<ArticleObject>> GetArticlesList([AliasAs("sort")] string sortOrder="desc");

        [Get("/articles/{id}")]
        Task<ArticleObject> GetArticle([AliasAs("id")] int articleId);

        [Get("/authors/{id}/articles")]
        Task<List<ArticleObject>> GetArticlesByAuthor([AliasAs("id")] int authorId);

        [Post("/articles")]
        Task<ArticleObject> CreateArticle([Body]ArticleObject article);

        [Put("/articles")]
        Task<ArticleObject> UpdateArticle([Body]ArticleObject article);

        [Delete("/articles/{id}")]
        Task RemoveArticle([AliasAs("id")] int articleId);
    }
}
