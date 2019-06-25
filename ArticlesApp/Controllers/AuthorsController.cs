using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ArticlesApp.Repositories;
using ArticlesApp.Model;
using ArticlesApp.ViewModels;

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
        public IActionResult GetAll()
        {
            IEnumerable<AuthorViewModel> authors = unitOfWork.Authors.GetAuthorsViewModels();
            if(authors.Count()!=0)
            {
                return Ok(unitOfWork.Authors.GetAuthorsViewModels());
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var result = unitOfWork.Authors.GetAuthorViewModel(id);
            if(result!=null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}