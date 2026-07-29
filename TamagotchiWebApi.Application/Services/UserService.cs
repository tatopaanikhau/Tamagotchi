using TamagotchiWebApi.Application.Interfaces;
using TamagotchiWebApi.Application.Interfaces.IRepo;
using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository<User> _userRepository;
    public UserService(IUserRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
    
    public Task<User> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> Add(User entity)
    {
        await _userRepository.AddAsync(entity);
        return entity;
    }

    public Task<User?> Update(Guid id, string u)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}