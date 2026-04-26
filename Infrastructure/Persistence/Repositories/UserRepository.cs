using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public Task<User?> GetUserByEmailAsync(string email) => _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
}