using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using TamagotchiWebApi.Application.Interfaces;
using TamagotchiWebApi.Application.Interfaces.IRepo;
using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Application.Services;

public class AuthServices : IAuthServices
{
    private readonly IUserRepository<User> _userRepository;
    private readonly IConfiguration _configuration;
    private string response = string.Empty;
    
    public AuthServices(IUserRepository<User> userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }
    public async Task<bool> Register(string name, string email, string password)
    {
        //checking if the email is already registered
        if (!await validateEmail(email))
        {
            //create User
            User u = new User()
            {
                Name = name,
                Email = email
            };
            //hash the password
            var hasher = new PasswordHasher<User>();
            u.PasswordHash = hasher.HashPassword(u, password);
            //save to db 
            await _userRepository.AddAsync(u);
            return true;
        }
        else
        {
            return false;
            
        }

    }

    //login (token) -> validate user + generate token
    public async Task<string?> Login(string email, string password)
    {
        //find the user first using email
        var user = await _userRepository.GetByEmail(email);
        if (user is null)
        {
            return null;
        }
        else
        {
            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }
            else
            {
                return createToken(user);
            }
        }
        
    }

    public async Task<bool> validateEmail(string email)
    {
        // to check if the email already exists
        var existingUser = await _userRepository.GetByEmail(email);
        return existingUser is not null;
    }

    public string createToken(User user)
    {
        var claims = new  []
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email)
        }
        ;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:Key"] ?? throw new InvalidOperationException()));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiration = int.Parse(_configuration["jwt:Expiry"] ?? "60");
        var expiresAt = DateTime.UtcNow.AddDays(expiration);
        var token = new JwtSecurityToken(
            issuer: _configuration["jwt:Issuer"],
            audience: _configuration["jwt:Audience"],
            claims: claims,
            expires: expiresAt,
            signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}