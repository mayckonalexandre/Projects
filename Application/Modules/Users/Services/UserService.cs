using Application.Common.Dtos;
using Domain.Contracts;
using static Application.Exceptions.Exceptions;

namespace Application.Modules.Users.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id) ?? throw new NoContentException("User not found");

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }
}   
