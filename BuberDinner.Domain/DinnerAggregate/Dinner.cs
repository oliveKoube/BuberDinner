using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate
{
    public sealed class Dinner : AggregateRoot<DinnerId, Guid>
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
            Location location)
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
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
        }

        public static Dinner Create(string name, string description, DateTime startDateTime,
            DateTime endDateTime, DateTime startedDateTime, DateTime endedDateTime, string status,
            bool isPublic, int maxGuests, Price price, MenuId menuId, HostId hostId, Uri image,
            Location location) 
            => new(DinnerId.CreateUnique(), name, description, startDateTime, endDateTime,
                startedDateTime, endedDateTime, status, isPublic, maxGuests, price, menuId, hostId, image,
                location);
    }
}
