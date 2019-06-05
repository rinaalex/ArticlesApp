using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ArticlesApp.Repositories;
using ArticlesApp.Model;

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
            return Ok(unitOfWork.Authors.All());
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            return Ok(unitOfWork.Authors.Get(id));
        }
    }
}