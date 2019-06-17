using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ArticlesApp.Model;
using ArticlesApp.ViewModels;
using ArticlesApp.Repositories;

namespace ArticlesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;

        public AccountsController(ArticlesContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var result = new AuthResult();

            if (ModelState.IsValid)
            {             
                var user = unitOfWork.Authors.
                    Find(p => p.Login == model.Login && p.Password == model.Password).FirstOrDefault();

                if (user!=null)
                {
                    await Authentificate(user.Login);
                    result.IsAuthentificated = true;
                    result.Login = user.Login;
                    return Ok(result); 
                }

                result.IsAuthentificated = false;
                //ModelState.AddModelError("", "Неверный логин и/или пароль.");
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("Register")]
        public async Task <IActionResult> Register(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = unitOfWork.Authors.Find(p => p.Login == model.Login).FirstOrDefault();
                if (user == null)
                {
                    unitOfWork.Authors.Add(new Author { Login = model.Login, Password = model.Password });
                    unitOfWork.Complete(); //await
                    await Authentificate(model.Login);
                    return Ok(); //redirection 
                }
                else
                    ModelState.AddModelError("", "Выбранный вами логин уже занят!");
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("LogOut")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return NoContent();
        }

        private async Task Authentificate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", 
                ClaimsIdentity.DefaultRoleClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}