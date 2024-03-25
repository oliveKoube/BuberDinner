using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate;

public sealed class Host : AggregateRoot<HostId, string>
{
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Uri ProfilImage { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public UserId UserId { get; private set; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Host(HostId hostId, string firstName, string lastName, Uri profilImage,
        AverageRating averageRating, UserId userId)
        : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfilImage = profilImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = DateTime.Now;
        UpdatedDateTime = DateTime.Now;
    }

    public static Host Create(string firstName, string lastName, Uri profilImage,
        AverageRating averageRating, UserId userId)
        => new(HostId.Create(userId), firstName, lastName, profilImage, averageRating,
            userId);

#pragma warning disable CS8618
    private Host()
    {
    }
#pragma warning restore CS8618
}
