using MediatR;

namespace Application.Modules.Users.UseCases.Command;

public class CreateUserCommand : IRequest
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
