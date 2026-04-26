using Application.Common.Dtos;

namespace Application.Services.User;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(int id);
}
