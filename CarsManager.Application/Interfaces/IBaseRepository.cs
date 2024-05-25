using System.Linq.Expressions;
using CarsManager.Domain.Entities;

namespace CarsManager.Application.Interfaces;

public interface IRepository<T> where T : BaseEntity 
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    void Add(T entity);
    void Update(T entity);
    Task<bool> SaveChangesAsync();
    Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
    void Delete(T entity);
}