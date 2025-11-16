using Microsoft.EntityFrameworkCore;
using Ordermanagement.Infrastructure.Persistence;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repositories.Base;
using System.Linq.Expressions;

namespace Ordermanagement.Infrastructure.Repositories.Base;

public class QueryRepository<T> : IQueryRepository<T> where T : Entity
{
    private readonly ReadDbContext _readDbContext;
    private readonly DbSet<T> _dbSet;

    public QueryRepository(ReadDbContext readDbContext)
    {
        _readDbContext = readDbContext;
        _dbSet = _readDbContext.Set<T>();
    }
    public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> query = _dbSet;
        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return await query.ToListAsync();
    }
}
