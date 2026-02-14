using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly WebDbContext _WebDbContext;
        public UserController(WebDbContext WebDbContext,IConfiguration config)
        {
            _WebDbContext = WebDbContext;
            _config = config;
        }


        [HttpPost("login")]
        public IActionResult Post(string username, string password)
        {
            try
            {
                var user = _WebDbContext.Users.Where(x => x.UserId == username && x.Password == password).FirstOrDefault();
                if (user != null)
                {
                    return Ok(Genrate(user));
                }
                else
                {
                    return Ok("Please Check UserID Or Password");
                }
            }
            catch (Exception)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
        }
          private object Genrate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:key"]));
            var cred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]{
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Sid,user.SrNo.ToString())
            };
            var Token = new JwtSecurityToken(_config["jwt:issuer"],
                _config["jwt:audience"],
                claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: cred);
            return (new JwtSecurityTokenHandler().WriteToken(Token));
        }

    }
}
