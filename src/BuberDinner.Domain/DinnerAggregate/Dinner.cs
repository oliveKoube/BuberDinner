using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate;

public sealed class Dinner : AggregateRoot<DinnerId, Guid>
{
    private readonly List<DinnerReservation> _dinnerReservations = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DateTime StartedDateTime { get; private set; }
    public DateTime EndedDateTime { get; private set; }
    public string Status { get; private set; }
    public bool IsPublic { get; private set; }
    public int MaxGuests { get; private set; }
    public Price Price { get; private set; }
    public MenuId MenuId { get; private set; }
    public HostId HostId { get; private set; }
    public Uri Image { get; private set; }
    public Location Location { get; private set; }
    public IReadOnlyList<DinnerReservation> DinnerReservations => _dinnerReservations.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

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
        bool isPublic, int maxGuests, MenuId menuId, HostId hostId, Uri image,
        Location location)
        => new(DinnerId.CreateUnique(), name, description, startDateTime, endDateTime,
            startedDateTime, endedDateTime, status, isPublic, maxGuests, Price.CreateNew(), menuId, hostId, image,
            location);

#pragma warning disable CS8618
    private Dinner()
    {
    }
#pragma warning restore CS8618
}
