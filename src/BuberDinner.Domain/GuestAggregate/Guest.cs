using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.Entities;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate
{
    public sealed class Guest : AggregateRoot<GuestId, Guid>
    {
        private readonly List<DinnerId> _upcomingDinnerIds;
        private readonly List<DinnerId> _pastDinnerIds;
        private readonly List<DinnerId> _pendingDinnerIds;
        private readonly List<BillsId> _billsIds;
        private readonly List<MenuReviewId> _menuReviewIds;
        private readonly List<GuestRating> _guestRatings;
        public string FirstName { get; }
        public string LastName { get; }
        public Uri ProfilImage { get; }
        public AverageRating AverageRating { get; }
        public UserId UserId { get; }
        public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
        public IReadOnlyList<BillsId> BillsIds => _billsIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public IReadOnlyList<GuestRating> GuestRatings => _guestRatings.AsReadOnly();
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        private Guest(GuestId guestId, string firstName, string lastName, Uri profilImage, AverageRating averageRating,
            UserId userId)
            : base(guestId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfilImage = profilImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
        }

        public static Guest Create(string firstName, string lastName, Uri profilImage, AverageRating averageRating,
            UserId userId)
            => new(GuestId.CreateUnique(), firstName, lastName, profilImage, averageRating, userId);
    }
}
