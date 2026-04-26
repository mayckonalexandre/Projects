using Application.Common.Dtos;
using Application.Modules.Users.Services;
using Application.Modules.Users.UseCases.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IMediator mediator, IUserService userService) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IUserService _userService = userService;

    [HttpGet("{id}")]
    public async Task<IActionResult> Index(int id)
    {
        UserDto result = await _userService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }
}
