using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Application.Interfaces;

public interface IPetServices : IBaseServices<Pet>
{
    Task<Pet> Rest(Guid id);
    Task<Pet> Walk(Guid id);
    
    Task<IEnumerable<Pet>> GetAll(Guid id);
}