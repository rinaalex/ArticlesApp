using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Refit;
using ArticlesApp.DAL.DataObjects;

namespace ArticlesApp.DAL.DataServices
{
    [Headers("Authorization: Bearer")]
    public interface IReviewsDataService
    {
        [Get("/authors/{id}/reviews")]
        Task<List<ReviewObject>> GetReviewsByAuthor([AliasAs("id")] int authorId);

        [Get("/articles/{id}/reviews")]
        Task<List<ReviewObject>> GetReviewsByArticle([AliasAs("id")] int articleId);

        [Post("/articles/{id}/reviews")]
        Task<ReviewObject> CreateReview([AliasAs("id")] int articleId, [Body] ReviewObject review);

        [Put("/reviews")]
        Task<ReviewObject> UpdateReview([Body] ReviewObject review);

        [Delete("/reviews/{id}")]
        Task <HttpResponseMessage>RemoveReview([AliasAs("id")] int reviewId);
    }
}
