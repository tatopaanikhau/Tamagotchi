using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TamagotchiWebApi.Application;
using TamagotchiWebApi.Domain;
using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    private AppDbContext _context;
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        
    }
    
    public async Task DeleteAsync(Guid id)
    {
        await _context.Set<T>().Where(p => p.Id == id).ExecuteDeleteAsync();  
    }
}