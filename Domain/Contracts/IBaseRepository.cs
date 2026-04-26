namespace Domain.Contracts;

public interface IBaseRepository<T>
{
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
}
