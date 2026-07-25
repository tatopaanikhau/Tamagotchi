using TamagotchiWebApi.Domain;

namespace TamagotchiWebApi.Application;

public interface IBaseRepository<T> where T : BaseModel
{
    Task<T> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task DeleteAsync(Guid id);
    Task<int> SaveChangesAsync();
}