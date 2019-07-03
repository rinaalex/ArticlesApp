using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ArticlesApp.Repositories;
using ArticlesApp.Model;
using ArticlesApp.ViewModels.Reviews;
using ArticlesApp.ViewModels.Reviews.QueryObjects;

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
        public IActionResult GetByAuthor(int id, [FromQuery] string sort="")
        {
            IEnumerable<Review> reviews = unitOfWork.ReviewsRepository.Get(filter: q => q.AuthorId == id,
                orderBy: r => r.OrderBy(q => q.PublicationDate), includeProperties: "Author,Article");
            if (reviews.Count() != 0)
            {
                if (ReviewListSort.OrderDictionary.ContainsKey(sort))
                    return Ok(reviews.MaptoViewModel().OrderReviewsBy(ReviewListSort.OrderDictionary[sort]));
                return Ok(reviews.MaptoViewModel().OrderReviewsBy(ReviewOrderByOptions.Simple));
            }
            return NotFound();
        }

        // Все отзывы на статью
        [HttpGet("/api/articles/{id}/reviews")]
        public IActionResult Get(int id, [FromQuery] string sort="")
        {
            IEnumerable<Review> reviews = unitOfWork.ReviewsRepository.Get(
                filter: r => r.ArticleId == id, includeProperties: "Article,Author");
            if (reviews.Count() != 0)
            {
                if (ReviewListSort.OrderDictionary.ContainsKey(sort))
                    return Ok(reviews.MaptoViewModel().OrderReviewsBy(ReviewListSort.OrderDictionary[sort]));
                return Ok(reviews.MaptoViewModel().OrderReviewsBy(ReviewOrderByOptions.Simple));
            }
            return NotFound();
        }

        [HttpPost("/api/articles/{id}/reviews")]
        public IActionResult CreateReview(int id, [FromBody]ReviewViewModel newReview)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Article article = unitOfWork.ArticlesRepository.GetById(id);
                    if (article != null)
                    {
                        Review review = new Review
                        {
                            ArticleId = id,
                            AuthorId = int.Parse(User.Identity.Name),
                            Content = newReview.Content,
                            NumStars = newReview.NumStars,
                            PublicationDate = DateTime.UtcNow
                        };
                        unitOfWork.ReviewsRepository.Add(review);
                        unitOfWork.Complete();
                        newReview = unitOfWork.ReviewsRepository.Get(filter: r => r.Id == review.Id,
                            includeProperties: "Article,Author").FirstOrDefault().MapToViewModel();
                        return CreatedAtAction(nameof(Get), new { id = review.Id }, newReview);
                    }
                }
                ModelState.AddModelError("error", "Невозможно добавить отзыв. Статья не существует.");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("error", "Не удалось сохранить изменения, попробуйте выполнить операцию позже.");
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Update([FromBody]ReviewViewModel updatedReview)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Review review = unitOfWork.ReviewsRepository.Get(filter: r => r.Id == updatedReview.Id,
                                    includeProperties: "Article,Author").FirstOrDefault();
                    if (review != null)
                    {
                        if(review.AuthorId==int.Parse(User.Identity.Name))
                        {
                            review.Content = updatedReview.Content;
                            review.PublicationDate = DateTime.UtcNow;
                            unitOfWork.ReviewsRepository.Update(review);
                            unitOfWork.Complete();
                            updatedReview = unitOfWork.ReviewsRepository.Get(filter: r => r.Id == updatedReview.Id).FirstOrDefault().MapToViewModel();
                            return Ok(updatedReview);
                        }
                        ModelState.AddModelError("error", "Вы можете редактировать только свои отзывы.");
                        return Conflict(ModelState);
                    }
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("error", "Не удалось сохранить изменения, попробуйте выполнить операцию позже.");
            }            
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            Review review = unitOfWork.ReviewsRepository.GetById(id);
            if(review!=null)
            {
                if (review.AuthorId == int.Parse(User.Identity.Name))
                {
                    unitOfWork.ReviewsRepository.Delete(id);
                    unitOfWork.Complete();
                    return NoContent();
                }
                ModelState.AddModelError("error", "Вы можете удалять только свои отзывы.");
                return Conflict(ModelState);
            }
            return NotFound();
        }
    }
}