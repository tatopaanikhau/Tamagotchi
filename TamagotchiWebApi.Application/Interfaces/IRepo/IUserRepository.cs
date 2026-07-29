using TamagotchiWebApi.Domain;
using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Application.Interfaces.IRepo;

public interface IUserRepository<T> : IBaseRepository<T> where T : BaseModel
{
    Task<User?> GetByEmail(string email);
}