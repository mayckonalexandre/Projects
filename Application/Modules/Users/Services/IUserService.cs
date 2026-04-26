using Application.Common.Dtos;

namespace Application.Modules.Users.Services;

public interface IUserService 
{
    Task<UserDto> GetByIdAsync(int id);
}
