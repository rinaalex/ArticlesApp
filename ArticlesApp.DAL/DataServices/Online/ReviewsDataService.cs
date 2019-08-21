using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Refit;
using ArticlesApp.DAL.DataObjects;

namespace ArticlesApp.DAL.DataServices.Online
{
    public class ReviewsDataService: BaseOnlineDataService
    {
        protected readonly IReviewsDataService _reviewsDataService;

        public ReviewsDataService(string token=""): base()
        {
            _reviewsDataService = RestService.For<IReviewsDataService>(Constants.BaseAddress, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(token)
            });
        }

        public async Task<List<ReviewObject>> GetReviewsByAuthor(int authorId)
        {
            try
            {
                return await _reviewsDataService.GetReviewsByAuthor(authorId);
            }
            catch(ApiException ex)
            {
                return null;
            }
        }

        public async Task<List<ReviewObject>> GetReviewsByArticle(int articleId)
        {
            try
            {
                return await _reviewsDataService.GetReviewsByArticle(articleId);
            }
            catch (ApiException ex)
            {
                return null;
            }
        }

        public async Task<ReviewObject> CreateReview(int articleId, ReviewObject review)
        {
            try
            {
                return await _reviewsDataService.CreateReview(articleId, review);
            }
            catch (ApiException ex)
            {
                return null;
            }
        }

        public async Task<ReviewObject> UpdateReview(ReviewObject review)
        {
            try
            {
                return await _reviewsDataService.UpdateReview(review);
            }
            catch (ApiException ex)
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> RemoveReview(int reviewId)
        {
            try
            {
                return await _reviewsDataService.RemoveReview(reviewId);
            }
            catch(ApiException ex)
            {
                return null;
            }
        }
    }
}
