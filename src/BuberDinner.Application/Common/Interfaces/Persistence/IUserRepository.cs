using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(Email email);
    void Add(User user);
}
