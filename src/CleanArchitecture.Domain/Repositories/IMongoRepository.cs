using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories;
public interface IMongoRepository<T, TKey>
{
    IQueryable<T> Query { get; }

    Task<T?> GetByIdAsync(TKey id);

    Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> expression);

    Task<T> AddAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);

    Task<T> UpdateAsync(T entity);

    void Remove(T entity);

    Task RemoveRange(IEnumerable<T> entities);
}
