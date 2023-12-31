using Microsoft.AspNetCore.Mvc;
using TDDDemo.Services;

namespace TDDDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get()
    {
        var users = await _userService.GetAllUsers();
        if (users.Any())
            return Ok(users);
        else return NotFound();
    }
}