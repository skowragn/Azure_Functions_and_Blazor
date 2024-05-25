using System.Linq.Expressions;
using CarsManager.Application.Interfaces;
using CarsManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CarsManager.Orleans.Infrastructure.Persistence.DbContext;

namespace CarsManager.Infrastructure.Persistence.Repositories;

public class Repository<T>(AppDbContext context) : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly DbSet<T> _entities = context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _entities.SingleOrDefaultAsync(s => s.Id == id);
    }

    public void Add(T entity)
    {
        _entities.Add(entity);
    }

    public void Update(T entity)
    {
        _entities.Update(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
    }

    public async Task<T?> FindByConditionAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public void Delete(T entity)
    {
        _entities.Remove(entity);
    }
}