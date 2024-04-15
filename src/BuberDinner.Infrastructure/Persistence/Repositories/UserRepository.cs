using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.UserAggregate;
using BuberDinner.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

internal sealed class UserRepository : Repository<User, UserId>,IUserRepository
{
    public UserRepository(BuberDinnerDbContext buberDinnerDbContext) :
        base(buberDinnerDbContext)
    {

    }
    public async Task<User?> GetUserByEmailAsync(Email email, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<User>().SingleOrDefaultAsync(x=>x.Email==email,cancellationToken);
    }
}
