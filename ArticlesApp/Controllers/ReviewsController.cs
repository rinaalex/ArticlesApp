using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArticlesApp.Repositories;
using ArticlesApp.Model;
using ArticlesApp.ViewModels;

namespace ArticlesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;

        public ReviewsController(ArticlesContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

    }
}