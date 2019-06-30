using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArticlesApp.Repositories;
using ArticlesApp.Model;
using ArticlesApp.ViewModels;
using ArticlesApp.ViewModels.QueryObjects;

namespace ArticlesApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;

        public ReviewsController(ArticlesContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet("/api/authors/{id}/reviews")]
        public IActionResult GetByAuthor(int id)
        {
            IEnumerable<ReviewViewModel> reviews = unitOfWork.Reviews.GetReviewsViewModelsByAuthor(id);
            if (reviews.Count() != 0)
            {
                return Ok(reviews);
            }
            return NotFound();
        }

        [HttpGet("/api/articles/{id}/reviews")]
        public IActionResult Get(int id)
        {
            IEnumerable<ReviewViewModel> reviews = unitOfWork.Reviews.GetReviewsViewModels(id);
            if (reviews.Count() != 0)
            {
                return Ok(reviews);
            }
            return NotFound();
        }

        [HttpPost("/api/articles/{id}/reviews")]
        public IActionResult CreateReview(int id, [FromBody]ReviewViewModel newReview)
        {
            Review review = new Review
            {
                ArticleId = id,
                AuthorId = int.Parse(HttpContext.User.Identity.Name),
                Content = newReview.Content,
                NumStars = newReview.NumStars,
                PublicationDate = DateTime.UtcNow
            };
            unitOfWork.Reviews.Add(review);
            unitOfWork.Complete();
            newReview = unitOfWork.Reviews.GetReviewViewModel(review.Id);
            return Ok(newReview);
        }

        [HttpPut]
        public IActionResult Update([FromBody]ReviewViewModel updatedReview)
        {
            Review review = unitOfWork.Reviews.Find(r => r.Id == updatedReview.Id).FirstOrDefault();
            if(review!=null)
            {
                review.Content = updatedReview.Content;
                review.PublicationDate = DateTime.UtcNow;
                unitOfWork.Reviews.Update(review);
                unitOfWork.Complete();
                updatedReview = unitOfWork.Reviews.GetReviewViewModel(updatedReview.Id);
                return Ok(updatedReview);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            Review review = unitOfWork.Reviews.Get(id);
            if(review!=null)
            {
                unitOfWork.Reviews.Delete(id);
                unitOfWork.Complete();
                return NoContent();
            }
            return NotFound();
        }
    }
}