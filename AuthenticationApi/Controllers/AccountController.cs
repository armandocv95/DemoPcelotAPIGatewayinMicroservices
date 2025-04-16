using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(IConfiguration config) : ControllerBase
{
    private static ConcurrentDictionary<string,string> UserData = new ConcurrentDictionary<string, string>();

    //api/account/login/{email}/{password}
    [HttpPost("login/{email}/{password}")]
    public async Task<IActionResult> Login(string email, string password)
    {
        await Task.Delay(500);
        var getEmail = UserData!.Keys.Where(x => x.Equals(email)).FirstOrDefault();
        if(!string.IsNullOrEmpty(getEmail))
        {
            UserData.TryGetValue(getEmail, out string? getPassword);
            if (getPassword.Equals(password))
            {
                
                string jwtToken = GenerateToken(getEmail);
                return Ok(jwtToken);
            }
            else
            {
                return BadRequest("Wrong Password");
            }
        }
        else
        {
            return BadRequest("User Not Found");
        }
    }

    private string GenerateToken(string getEmail)
    {
        var key =Encoding.UTF8.GetBytes(config["Authentication:Key"]);
        var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key);
        var credential = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);
        var claims = new[] { new Claim(ClaimTypes.Email, getEmail!) };
        var token = new JwtSecurityToken(
            issuer: config["Authentication:Issuer"],
            audience: config["Authentication:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credential
        );
        // Simulate token generation
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [HttpPost("register/{email}/{password}")]
    public async Task<IActionResult> Register(string email, string password)
    {
        await Task.Delay(500);
        var getEmail = UserData!.Keys.Where(x => x.Equals(email)).FirstOrDefault();
        if (string.IsNullOrEmpty(getEmail))
        {
            UserData.TryAdd(email, password);
            return Ok("User Created");
        }
        else
        {
            return BadRequest("User Already Exists");
        }
    }
}
