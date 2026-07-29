using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TamagotchiWebApi.Api.Controllers;

public class UserController : ControllerBase
{
    [Route("api/[controller]")]
    [Authorize]
}