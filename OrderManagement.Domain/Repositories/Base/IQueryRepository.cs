using OrderManagement.Domain.Entities;
using System.Linq.Expressions;

namespace OrderManagement.Domain.Repositories.Base;

public interface IQueryRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? predicate = null);
}
