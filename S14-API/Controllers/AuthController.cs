using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using S14_API.Data;
using S14_API.Models;
using S14_API.Models.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace S14_API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly IConfiguration _configuration;

        private readonly IPasswordHasher<Student> _passwordHasher;

        public AuthController(AppDbContext context, IConfiguration configuration, IPasswordHasher<Student> passwordHasher)
        {
            _context = context;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("login/student")]
        public async Task<IActionResult> LoginStudent([FromBody] Login model)
        {
            var student = await _context.Students
                                .SingleOrDefaultAsync(s => s.Username == model.Username);
            if (student != null && VerifyPassword(model.Password, student.Password))
            {
                var token = GenerateJwtToken(student.Username, "Student");
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }

        [HttpPost("login/teacher")]
        public async Task<IActionResult> LoginTeacher([FromBody] Login model)
        {
            var student = await _context.Students
                                .SingleOrDefaultAsync(s => s.Username == model.Username);
            if (student != null && VerifyPassword(model.Password, student.Password))
            {
                var token = GenerateJwtToken(student.Username, "Teacher");
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string username, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserType", role)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private bool VerifyPassword(string providedPassword, string storedHash)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, storedHash, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
