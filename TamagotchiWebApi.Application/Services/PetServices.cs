
using TamagotchiWebApi.Application.Interfaces;
using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Application.Services;

public class PetServices : IPetServices
{
    private IBaseRepository<Pet> _repo;
    public PetServices(IBaseRepository<Pet> repo)
    {
        _repo = repo;
    }
    public Task<Pet> Rest()
    {
        throw new NotImplementedException();
    }

    public Task<Pet> Walk()
    {
        throw new NotImplementedException();
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