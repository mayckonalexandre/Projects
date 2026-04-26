using Application.Common.Dtos;
using Application.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("{id}")]
    public async Task<IActionResult> Index(int id)
    {
        UserDto result = await _userService.GetByIdAsync(id);
        return Ok(result);
    }
}
