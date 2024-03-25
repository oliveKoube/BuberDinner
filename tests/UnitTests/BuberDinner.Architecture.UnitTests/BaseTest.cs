using System.Reflection;
using BuberDinner.Application.Common.Messaging;
using BuberDinner.Domain.UserAggregate;
using BuberDinner.Infrastructure.Persistence;

namespace BuberDinner.Architecture.UnitTests;

public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(User).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(IBaseCommand).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(BuberDinnerDbContext).Assembly;
    protected static readonly Assembly ApiAssembly = typeof(Program).Assembly;
}
