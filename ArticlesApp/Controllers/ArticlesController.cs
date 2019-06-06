using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ArticlesApp.Model;
using ArticlesApp.Repositories;

namespace ArticlesApp.Controllers
{
    //[Authorize]
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
            return Ok(unitOfWork.Articles.GetArticlesViewModels());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var article = unitOfWork.Articles.GetArticleViewModel(id);
            if (article!=null)
                return Ok(article);
            return NotFound();
        }
    }
}