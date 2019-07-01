using ArticlesApp.Model;
using ArticlesApp.Repositories;
using ArticlesApp.ViewModels;
using ArticlesApp.ViewModels.QueryObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult Get()
        {
            IEnumerable<Article> articles = unitOfWork.ArticlesRepository.Get(includeProperties: "Author,Reviews");
            if (articles.Count() != 0)
            {
                return Ok(articles.MapToViewModel());
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
        public IActionResult GetArticlesByAuthor(int id)
        {
            IEnumerable<Article> articles = unitOfWork.ArticlesRepository.Get(
                filter: a => a.AuthorId == id, includeProperties: "Author,Reviews");
            if (articles.Count() != 0)
            {
                return Ok(articles.MapToViewModel());
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
                        AuthorId = int.Parse(this.HttpContext.User.Identity.Name)
                    };
                    unitOfWork.ArticlesRepository.Add(article);
                    unitOfWork.Complete();
                    article = unitOfWork.ArticlesRepository.Get(
                        filter: a => a.Id == article.Id, includeProperties: "Author,Reviews").FirstOrDefault();
                    return Ok(article.MapToViewModel());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Не удалось сохранить изменения, попробуйте выполнить операцию позже.");
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
                        article.Title = updatedArticle.Title;
                        article.Content = updatedArticle.Content;
                        //article.UpdateDate = DateTime.UtcNow;
                        unitOfWork.ArticlesRepository.Update(article);
                        unitOfWork.Complete();
                        article = unitOfWork.ArticlesRepository.Get(
                            filter: a => a.Id == article.Id, includeProperties: "Author,Reviews").FirstOrDefault();
                        return Ok(article.MapToViewModel());
                    }
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Не удалось сохранить изменения, попробуйте выполнить операцию позже.");
            }            
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            Article article = unitOfWork.ArticlesRepository.GetById(id);
            if (article != null)
            {
                unitOfWork.ArticlesRepository.Delete(id);
                unitOfWork.Complete();
                return NoContent();
            }
            return NotFound();
        }

    }
}