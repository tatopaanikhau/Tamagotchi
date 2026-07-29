using TamagotchiWebApi.Domain;

namespace TamagotchiWebApi.Application.Interfaces.IRepo;

public interface IPetRepository<T> : IBaseRepository<T> where T : BaseModel
{
    Task<IEnumerable<T>> GetAllAsync(Guid id);

}