using Microsoft.EntityFrameworkCore;
using TamagotchiWebApi.Application.Interfaces.IRepo;
using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Infrastructure.Repositories;

public class PetRepository : BaseRepository<Pet>, IPetRepository<Pet>
{
    private readonly AppDbContext _context;
    public PetRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Pet>> GetAllAsync(Guid id)
    {
        return await _context.Pets.Where(p => p.OwnerId == id).ToListAsync();
    }
}