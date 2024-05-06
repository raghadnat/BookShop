using BookShop.DAL.Context;
using BookShop.DAL.Entites;
using BookShop.Domain.DTOs;
using BookShop.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using BookShop.DAL.Repositories;
using System.Security.Claims;

namespace BookShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly DBContext _context;
        private IConfiguration _config;
        private readonly StudentRepository _Repository;

        public LoginController(StudentRepository Repo, IConfiguration config)
        {
            _Repository = Repo;
            _config = config;

        }

        [HttpGet("api/Signin")]
        public async Task<ActionResult<string>> Signin(string UserName, int Number)
        {
            var student = await _Repository.GetByStudentNumebrsync(Number, UserName);
            var tokenString = "";
            if (student == null)
            {
                return BadRequest("Invalid Login credentials!");
            }
            tokenString = GenerateJSONWebToken(student);

            return tokenString;
        }
       
        private string GenerateJSONWebToken(Student userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
             new Claim(JwtRegisteredClaimNames.Sub, userInfo.Name),
             new Claim(JwtRegisteredClaimNames.Email, userInfo.Name),
             new Claim("Id", userInfo.Id.ToString()),
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
