using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using quanao.Models;
using quanao.Services;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
namespace quanao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AdminService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(AdminService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AdminLoginDto loginDto)
        {
            var user = await _userService.GetByUsernameAsync(loginDto.Username);

            if (user == null || user.pass != loginDto.Password)
            {
                return Unauthorized(new { success = false, message = "Invalid username or password" });
            }

            var token = GenerateJwtToken(user);

            return Ok(new { success = true, token = token });
        }

        private string GenerateJwtToken(AdminAccount user)
        {
            var jwtKey = _configuration["Jwt:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                },
                expires: DateTime.Now.AddMonths(1), // Token có hiệu lực 1 tháng
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
