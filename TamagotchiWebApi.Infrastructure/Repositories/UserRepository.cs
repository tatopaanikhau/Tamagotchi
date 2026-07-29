using Microsoft.EntityFrameworkCore;
using TamagotchiWebApi.Application.Interfaces.IRepo;
using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User> , IUserRepository<User>
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
   
    public async Task<User?> GetByEmail(string email)
    {
        var u = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return u;
    }
}