using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Application.Interfaces;

public interface IPetServices : IBaseServices<Pet>
{
    Pet Rest();
    Pet Walk();
}