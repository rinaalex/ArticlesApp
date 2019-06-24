using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ArticlesApp.Model;
using ArticlesApp.ViewModels;
using ArticlesApp.Repositories;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.Security.Claims;

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
        [Route("Token")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var result = new AuthResult();

            if (ModelState.IsValid)
            {
                var identity = GetIdentity(model.Login, model.Password);

                if (identity == null)
                {
                    result.IsAuthentificated = false;
                    return BadRequest("Неверный логин и/или парль!");
                }

                // Создание токена
                var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: DateTime.UtcNow,
                    claims: identity.Claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                    );

                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                result.IsAuthentificated = true;
                result.Login = model.Login;
                result.Token = encodedJwt;

                return Ok(result); // сериализация?
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("Register")]
        public async Task <IActionResult> Register(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var identity = GetIdentity(model.Login, model.Password);
                
                if (identity == null)
                {
                    unitOfWork.Authors.Add(new Author { Login = model.Login, Password = model.Password });
                    unitOfWork.Complete(); //await?
                    // авторизация?
                    return Ok(); //redirection ?
                }
                else
                    ModelState.AddModelError("", "Выбранный вами логин уже занят!");
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("LogOut")]
        public IActionResult LogOut()
        {           
            return NoContent();
        }

        private ClaimsIdentity GetIdentity(string login, string password)
        {
            var user = unitOfWork.Authors.
                    Find(p => p.Login == login && p.Password == password).FirstOrDefault();

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "Token", 
                ClaimsIdentity.DefaultRoleClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return identity;            
        }
    }
}