using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Application.Interfaces;

public interface IAuthServices
{
    Task<bool> Register(string name, string email, string password);
    Task<string?> Login(string email, string password);
    Task<bool> validateEmail(string email);
    string createToken(User user);
}