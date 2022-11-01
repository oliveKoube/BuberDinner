﻿using BuberDinner.Domain.Bills.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner
{
    public sealed class Dinner : AggregateRoot<DinnerId>
    {
        private readonly List<DinnerReservation> _dinnerReservation;
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime StartedDateTime { get; }
        public DateTime EndedDateTime { get; }
        public string Status { get; }
        public bool IsPublic { get; }
        public int MaxGuests { get; }
        public Price Price { get; }
        public MenuId MenuId { get; }
        public HostId HostId { get; }
        public Uri Image { get; }
        public Location Location { get; }
        public IReadOnlyList<DinnerReservation> DinnerReservations => _dinnerReservation.AsReadOnly();
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        private Dinner(DinnerId dinnerId, string name, string description, DateTime startDateTime,
            DateTime endDateTime, DateTime startedDateTime, DateTime endedDateTime, string status,
            bool isPublic, int maxGuests, Price price, MenuId menuId, HostId hostId, Uri image, 
            Location location, DateTime createdDateTime, DateTime updatedDateTime)
            : base(dinnerId)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            StartedDateTime = startedDateTime;
            EndedDateTime = endedDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            MenuId = menuId;
            HostId = hostId;
            Image = image;
            Location = location;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Dinner Create(string name, string description, DateTime startDateTime,
            DateTime endDateTime, DateTime startedDateTime, DateTime endedDateTime, string status,
            bool isPublic, int maxGuests, Price price, MenuId menuId, HostId hostId, Uri image,
            Location location) 
            => new(DinnerId.CreateUnique(), name, description, startDateTime, endDateTime,
                startedDateTime, endedDateTime, status, isPublic, maxGuests, price, menuId, hostId, image,
                location,DateTime.UtcNow, DateTime.UtcNow);
    }
}
