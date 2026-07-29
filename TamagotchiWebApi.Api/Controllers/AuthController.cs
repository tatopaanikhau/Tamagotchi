using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TamagotchiWebApi.Application.DTOs;
using TamagotchiWebApi.Application.Interfaces;

namespace TamagotchiWebApi.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthServices _authServices;
    public AuthController(IAuthServices auth)
    {
        _authServices = auth;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var r = await _authServices.Login(loginRequest.Email, loginRequest.Password);
        if (r == null)
        {
            return Unauthorized("Invalid Email or Password");
        }
        else
        {
            return Ok(new {Token = r});
        }
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterDTO registerDto)
    {
        var r = await _authServices.Register(registerDto.Name, registerDto.Email, registerDto.Password);
        if (r == true)
        {
            return Created("", new { message = "Account Registered" });
        }
        else
        {
            return Conflict(new  { message = "Couldn't register account" });
        }
    }
}