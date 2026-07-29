using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TamagotchiWebApi.Application.Interfaces;
using TamagotchiWebApi.Application.Services;
using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private IPetServices _petServices;
    public UserController(IPetServices petServices)
    {
        _petServices = petServices;
    }

    [HttpGet("GetAllPets")]
    public async Task<ActionResult<IEnumerable<Pet>>> GetAllPets()
    {
        var ownerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (ownerIdClaim is null || !Guid.TryParse(ownerIdClaim, out var ownerId))
            return Unauthorized();
        var pets = await _petServices.GetAll(ownerId);
        return Ok(pets);
    }
}