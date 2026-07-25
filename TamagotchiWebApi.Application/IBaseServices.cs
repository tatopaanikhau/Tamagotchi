using TamagotchiWebApi.Domain;
using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Application;

public interface IBaseServices<T> where T : BaseModel
{
    Task<T> GetById(Guid id);
    Task<T> Add(T entity);
    Task<T?> Update(Guid id, string u);
    Task Delete(Guid id);
}