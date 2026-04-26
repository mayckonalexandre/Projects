using Domain.Entities;

namespace Domain.Contracts;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
}
