using Application.Common;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);
}