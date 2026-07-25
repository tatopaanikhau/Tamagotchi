using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Application.Interfaces;

public interface IPetServices : IBaseServices<Pet>
{
    Task<Pet> Rest();
    Task<Pet> Walk();
}