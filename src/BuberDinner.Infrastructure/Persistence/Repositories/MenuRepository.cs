using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

internal sealed class MenuRepository : Repository<Menu, MenuId>, IMenuRepository
{

    public MenuRepository(BuberDinnerDbContext buberDinnerDbContext)
        : base(buberDinnerDbContext)
    {
    }

    public override void Add(Menu menu)
    {
        DbContext.Add(menu);
    }
}
