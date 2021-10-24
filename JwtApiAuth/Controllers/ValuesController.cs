using JwtApiAuth.Core.Interfaces;
using JwtApiAuth.Core.Models;
using JwtApiAuth.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApiAuth.Api.Controllers
{
    [Route("api/")]
    public class HomeController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public HomeController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "User or password invalid" });

            var token = _tokenService.CreateToken(user);
            user.Password = "";
            
            return new
            {
                user = user,
                token = token
            };
        }
    }
}
