
using System.Security.Claims;
using TamagotchiWebApi.Application.Interfaces;
using TamagotchiWebApi.Application.Interfaces.IRepo;
using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Application.Services;

public class PetServices : IPetServices
{
    private IBaseRepository<Pet> _repo;
    private IPetRepository<Pet> _repoPet;
    public PetServices(IBaseRepository<Pet> repo, IPetRepository<Pet> petrepo)
    {
        _repo = repo;
        _repoPet = petrepo;
    }
    public async Task<Pet> Rest(Guid id)
    {
        var pet = await _repoPet.GetByIdAsync(id);
        var currEnery = pet.Energy;
        pet.Energy = currEnery + 20;
        if (currEnery > 80)
        {
            pet.Hunger = false;
            pet.Thirst = false;
        }
        await _repoPet.SaveChangesAsync();
        return pet;
    }

    public async Task<Pet> Walk(Guid id)
    {
        var pet = await _repoPet.GetByIdAsync(id);
        var currEnery = pet.Energy;
        pet.Energy = currEnery - 10;
        if (currEnery < 50)
        {
            pet.Hunger = true;
            pet.Thirst = true;
        }
        await _repoPet.SaveChangesAsync();
        return pet;

    }

    

    public async Task<IEnumerable<Pet>> GetAll(Guid id)
    {

        return await _repoPet.GetAllAsync(id);
    }
    

    public async Task<Pet> GetById(Guid id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task<Pet> Add(Pet entity)
    {
        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();
        return entity;
    }
    public async Task<Pet?> Update(Guid id, string u)
    {
        var pet = await _repo.GetByIdAsync(id);
        pet.Name = u;
        await _repo.SaveChangesAsync();
        return pet;
    }

    public async Task Delete(Guid id)
    {
        await _repo.DeleteAsync(id);
    }
}