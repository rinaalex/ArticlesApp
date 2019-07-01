using System;
using System.Collections.Generic;
using System.Linq;
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

        // Все отзывы автора
        [HttpGet("/api/authors/{id}/reviews")]
        public IActionResult GetByAuthor(int id)
        {
            IEnumerable<Review> reviews = unitOfWork.ReviewsRepository.Get(filter: q => q.AuthorId == id,
                orderBy: r => r.OrderBy(q => q.PublicationDate), includeProperties: "Author,Article");
            if (reviews.Count() != 0)
            {
                return Ok(reviews.MaptoViewModel());
            }
            return NotFound();
        }

        // Все отзывы на статью
        [HttpGet("/api/articles/{id}/reviews")]
        public IActionResult Get(int id)
        {
            IEnumerable<Review> reviews = unitOfWork.ReviewsRepository.Get(
                filter: r => r.ArticleId == id, includeProperties: "Article,Author");
            if (reviews.Count() != 0)
            {
                return Ok(reviews.MaptoViewModel());
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
            unitOfWork.ReviewsRepository.Add(review);
            unitOfWork.Complete();
            newReview = unitOfWork.ReviewsRepository.Get(filter: r=>r.Id==review.Id,
                includeProperties:"Article,Author").FirstOrDefault().MapToViewModel();
            return Ok(newReview);
        }

        [HttpPut]
        public IActionResult Update([FromBody]ReviewViewModel updatedReview)
        {
            Review review = unitOfWork.ReviewsRepository.Get(filter: r => r.Id == updatedReview.Id,
                includeProperties:"Article,Author").FirstOrDefault();
            if(review!=null)
            {
                review.Content = updatedReview.Content;
                review.PublicationDate = DateTime.UtcNow;
                unitOfWork.ReviewsRepository.Update(review);
                unitOfWork.Complete();
                updatedReview = unitOfWork.ReviewsRepository.Get(filter: r=>r.Id==updatedReview.Id).FirstOrDefault().MapToViewModel();
                return Ok(updatedReview);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            Review review = unitOfWork.ReviewsRepository.GetById(id);
            if(review!=null)
            {
                unitOfWork.ReviewsRepository.Delete(id);
                unitOfWork.Complete();
                return NoContent();
            }
            return NotFound();
        }
    }
}