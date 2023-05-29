using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        private MenuItem(MenuItemId menuItemId, string name, string description) 
            : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description) => new(MenuItemId.CreateUnique(), name, description);

#pragma warning disable CS8618
        protected MenuItem()
        {
        }
#pragma warning restore CS8618
    }
}
