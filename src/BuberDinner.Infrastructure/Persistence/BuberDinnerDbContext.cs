using System.Reflection;
using Bookify.Domain.Abstractions;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Infrastructure.Persistence.Interceptors;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BuberDinner.Infrastructure.Persistence;

public class BuberDinnerDbContext  : DbContext, IUnitOfWork
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
    public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor)
        : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public DbSet<Menu> Menus { get; set; } = null!;
    public DbSet<Menu> Bills { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);
#pragma warning disable S125
        /*modelBuilder.Model.GetEntityTypes()
            .SelectMany(m=>m.GetProperties())
            .Where(t=>t.IsPrimaryKey())
            .ToList()
            .ForEach(x=>x.ValueGenerated = ValueGenerated.Never);*/
#pragma warning restore S125
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
