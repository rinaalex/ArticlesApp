using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ArticlesApp.Model;
using ArticlesApp.Repositories;
using ArticlesApp.ViewModels;

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
            IEnumerable<ArticleViewModel> articles = unitOfWork.Articles.GetArticlesViewModels();
            if(articles.Count()!=0)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var article = unitOfWork.Articles.GetArticleViewModel(id);
            if (article!=null)
            {
                return Ok(article);
            }                
            return NotFound();
        }        

        [HttpPost]
        public IActionResult Create(ArticleViewModel newAarticle)
        {
            Article article = new Article
            {
                Title = newAarticle.Title,
                Content = newAarticle.Content,
                PublicationDate = DateTime.UtcNow,
                AuthorId = int.Parse(this.HttpContext.User.Identity.Name)
            };            
            unitOfWork.Articles.Add(article);
            unitOfWork.Complete();
            newAarticle = unitOfWork.Articles.GetArticleViewModel(newAarticle.Id);
            return Ok(newAarticle); // redirect?
        }

        [HttpPut]
        public IActionResult Update(ArticleViewModel updatedArticle)
        {
            Article article = unitOfWork.Articles.Get(updatedArticle.Id);
            if (article != null)
            {
                article.Title = updatedArticle.Title;
                article.Content = updatedArticle.Content;
                //article.UpdateDate = DateTime.UtcNow;
                unitOfWork.Articles.Update(article);
                unitOfWork.Complete();
                updatedArticle = unitOfWork.Articles.GetArticleViewModel(updatedArticle.Id);
                return Ok(updatedArticle);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            Article article = unitOfWork.Articles.Get(id);
            if(article!=null)
            {
                unitOfWork.Articles.Delete(id);
                unitOfWork.Complete();
                return NoContent();
            }
            return NotFound();
        }

    }
}