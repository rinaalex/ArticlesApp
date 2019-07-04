using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ArticlesApp.Repositories;
using ArticlesApp.Model;
using ArticlesApp.ViewModels.Authors.QueryObjects;

namespace ArticlesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        public AuthorsController(ArticlesContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] string sort="")
        {
            IEnumerable<Author> authors = unitOfWork.AuthorsRepository.Get(
                includeProperties:"Articles,Articles.Reviews");
            if(authors.Count()!=0)
            {
                return Ok(authors.MapToViewModel().OrderAuthorsBy(AuthorListSort.ParseOrderByOptions(sort)));
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            Author author = unitOfWork.AuthorsRepository.Get(filter:a=>a.Id==id,
                includeProperties: "Articles,Articles.Reviews").FirstOrDefault();
            if(author!=null)
            {
                return Ok(author.MapToViewModel());
            }
            return NotFound();
        }
    }
}