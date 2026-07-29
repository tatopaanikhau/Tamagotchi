using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TamagotchiWebApi.Application.DTOs;
using TamagotchiWebApi.Application.Interfaces;
using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PetsController : ControllerBase
{
    private readonly IPetServices _petServices;

    public PetsController(IPetServices petServices)
    {
        _petServices = petServices;
    }

    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Pet>> GetById(Guid id)
    {
        var pet = await _petServices.GetById(id);
        Console.WriteLine("===== GET BY ID : SUCCESS=======");
        return pet is null ? NotFound() : Ok(pet);
        
    }
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CreatePetDTO entity)
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (id is null)
            return Unauthorized();
        var pet1 = new Pet()
        {
            Name = entity.Name,
            OwnerId = Guid.Parse(id)
        };
        var pet = await _petServices.Add(pet1);
        return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
    }

    [HttpPatch("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] CreatePetDTO entity)
    {
        var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userid is null) return Unauthorized();
        
        await _petServices.Update(id, entity.Name);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _petServices.Delete(id);
        return Ok();
    }
}