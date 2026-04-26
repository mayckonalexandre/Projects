using Domain.Contracts;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<User?> GetByIdAsync(int id) => await Task.FromResult(new User
    {
        Id = id,
        Name = "John Doe",
        Email = "johndoe@example.com",
        Password = "123",
    });

    public async Task AddAsync(User user)
    {
        await Task.Delay(100);
    }

    public async Task UpdateAsync(User user) { await Task.Delay(100); }
}
