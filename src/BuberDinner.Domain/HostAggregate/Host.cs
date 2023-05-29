using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate
{
    public sealed class Host : AggregateRoot<HostId, string>
    {
        private readonly List<MenuId> _menuIds;
        private readonly List<DinnerId> _dinnerIds;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Uri ProfilImage { get; set; }
        public AverageRating AverageRating { get; set; }
        public UserId UserId { get; set; }
        public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

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
    }
}
