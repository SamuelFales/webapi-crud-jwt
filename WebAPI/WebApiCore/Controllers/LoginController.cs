using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApiCore.Infra.Authentication.Interfaces;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    { 

        private readonly ITokenService _tokenService;
        private readonly EmployeeDBContext _context;

        public LoginController(ITokenService tokenService, EmployeeDBContext context)
        {
            _tokenService = tokenService;
            _context = context;
        }

        public IActionResult Login(Users login)
        {
            IActionResult response = Unauthorized();

            var user  = AuthenticateUser(login);

            if (user != null)
            {
                var tokenStr = _tokenService.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenStr });
            }

            return response;
        }

        private Users AuthenticateUser(Users login)
        {
            var user = _context.Users.Where(u => u.UserId == login.UserId && u.AccessKey == login.AccessKey).FirstOrDefault();

            return user;
        }
    }
}