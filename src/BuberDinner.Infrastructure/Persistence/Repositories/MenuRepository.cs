using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly BuberDinnerDbContext _dbContext;

        public MenuRepository(BuberDinnerDbContext buberDinnerDbContext)
        {
            _dbContext = buberDinnerDbContext;
        }

        public void Add(Menu menu)
        {
            _dbContext.Add(menu);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(Menu menu)
        {
            await _dbContext.AddAsync(menu);
            await _dbContext.SaveChangesAsync();
        }
    }
}
