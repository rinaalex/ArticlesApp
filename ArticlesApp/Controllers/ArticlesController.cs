using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ArticlesApp.Model;
using ArticlesApp.Repositories;
using ArticlesApp.ViewModels.Articles.QueryObjects;
using ArticlesApp.ViewModels.Articles;

namespace ArticlesApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;

        public ArticlesController(ArticlesContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string sort="")
        {            
            IEnumerable<Article> articles = unitOfWork.ArticlesRepository.Get(includeProperties: "Author,Reviews");
            if (articles.Count() != 0)
            {                
                return Ok(articles.MapToViewModel().OrderArticlesBy(ArticleListSort.ParseOrderByOptions(sort)));
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Article article = unitOfWork.ArticlesRepository.Get(filter: a => a.Id == id, includeProperties: "Author,Reviews").FirstOrDefault();
            if (article != null)
            {
                return Ok(article.MapToViewModel());
            }
            return NotFound();
        }

        // Все статьи автора
        [HttpGet("/api/authors/{id}/articles")]
        public IActionResult GetArticlesByAuthor(int id, [FromQuery] string sort="")
        {
            IEnumerable<Article> articles = unitOfWork.ArticlesRepository.Get(
                filter: a => a.AuthorId == id, includeProperties: "Author,Reviews");
            if (articles.Count() != 0)
            {
                return Ok(articles.MapToViewModel().OrderArticlesBy(ArticleListSort.ParseOrderByOptions(sort)));
            }
            return NotFound();
        }               

        [HttpPost]
        public IActionResult Create([FromBody] ArticleViewModel newAarticle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Article article = new Article
                    {
                        Title = newAarticle.Title,
                        Content = newAarticle.Content,
                        PublicationDate = DateTime.UtcNow,
                        AuthorId = int.Parse(User.Identity.Name)
                    };
                    unitOfWork.ArticlesRepository.Add(article);
                    unitOfWork.Complete();
                    article = unitOfWork.ArticlesRepository.Get(
                        filter: a => a.Id == article.Id, includeProperties: "Author,Reviews").FirstOrDefault();
                    return CreatedAtAction(nameof(Get), new { id = article.Id }, article.MapToViewModel());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "Не удалось сохранить изменения, попробуйте выполнить операцию позже.");
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ArticleViewModel updatedArticle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Article article = unitOfWork.ArticlesRepository.GetById(updatedArticle.Id);
                    if (article != null)
                    {
                        if (article.AuthorId == int.Parse(User.Identity.Name))
                        {
                            article.Title = updatedArticle.Title;
                            article.Content = updatedArticle.Content;
                            //article.UpdateDate = DateTime.UtcNow;
                            unitOfWork.ArticlesRepository.Update(article);
                            unitOfWork.Complete();
                            article = unitOfWork.ArticlesRepository.Get(
                                filter: a => a.Id == article.Id, includeProperties: "Author,Reviews").FirstOrDefault();
                            return Ok(article.MapToViewModel());
                        }
                        ModelState.AddModelError("error", "Вы можете вносить изменения только в свои публикации.");
                        return Conflict(ModelState);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "Не удалось сохранить изменения, попробуйте выполнить операцию позже.");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            Article article = unitOfWork.ArticlesRepository.GetById(id);
            if (article != null)
            {
                if (article.AuthorId == int.Parse(User.Identity.Name))
                {
                    unitOfWork.ArticlesRepository.Delete(id);
                    unitOfWork.Complete();
                    return NoContent();
                }
                ModelState.AddModelError("error", "Вы можете удялять только свои публикации.");
                return Conflict(ModelState);
            }
            return NotFound();
        }

    }
}