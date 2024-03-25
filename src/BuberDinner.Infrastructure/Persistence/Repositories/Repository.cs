using BuberDinner.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

internal abstract class Repository<T,TId>
    where T : Entity<TId> where TId : notnull
{
    protected readonly BuberDinnerDbContext DbContext;

    protected Repository(BuberDinnerDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(
        TId id,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<T>()
            .FirstOrDefaultAsync(user => user.Id.Equals(id), cancellationToken);
    }

    public virtual void Add(T entity)
    {
        DbContext.Add(entity);
    }
}
