using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Infrastructure.Repositories;

public class PetRepository : BaseRepository<Pet>
{
    private readonly AppDbContext _context;
    public PetRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}