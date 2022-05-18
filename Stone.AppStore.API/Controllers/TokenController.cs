using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Stone.AppStore.Application.Models;
using Stone.AppStore.Domain.Entities;
using Stone.AppStore.Infraestructure.Identity;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Stone.AppStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authentication, IConfiguration configuration)
        {
            _authentication = authentication ??
                throw new ArgumentException(nameof(authentication));
            _configuration = configuration;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] UserModel userInfo)
        {
            User user = new User
            {
                Email = userInfo.Email,
                Active = true,
                Cpf = userInfo.Cpf,
                BirthDate = userInfo.BirthDate,
                Gender = userInfo.Gender,
                UserName = userInfo.Email,
                Password = userInfo.Password,
                Address = new Address
                {
                    Avenue = userInfo.Address.Avenue,
                    Cep = userInfo.Address.Cep,
                    City = userInfo.Address.City,
                    Complement = userInfo.Address.Complement,
                    Number = userInfo.Address.Number,
                    Uf = userInfo.Address.Uf,
                }
            };

            var result = await _authentication.RegisterUser(user);
            if (result)
            {
                return Ok($"User {userInfo.Email} was create successfully.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }
        }
        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] string email, string password)
        {
            var result = await _authentication.Authenticate(email, password);

            if (result)
            {
                return GenerateToken(email);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }
        }

        private UserToken GenerateToken(string email)
        {
            //declarações do usuario
            var claims = new[]
            {
            new Claim("Email", email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var privateKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
