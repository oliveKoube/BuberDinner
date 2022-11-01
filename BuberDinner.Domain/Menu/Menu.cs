﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        public string Name { get; }
        public string Description { get; }
        public AverageRating AverageRating { get; }
        public HostId HostId { get; }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public IReadOnlyList<DinnerId> Dinners => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        private Menu(MenuId menuId, string name, string description, AverageRating averageRating, HostId hostId,
            DateTime createdDateTime, DateTime updateDateTime)
            : base(menuId)
        {
            Name = name;
            Description = description;
            AverageRating = averageRating;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updateDateTime;
        }

        public static Menu Create(string name, string description, AverageRating averageRating,
            HostId hostId) => new(MenuId.CreateUnique(), name, description, averageRating,hostId, 
                DateTime.UtcNow,DateTime.UtcNow);
    }
}
