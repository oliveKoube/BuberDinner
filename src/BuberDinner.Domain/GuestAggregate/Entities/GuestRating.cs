using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.Common.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate.Entities
{
    public sealed class GuestRating : Entity<GuestRatingId>
    {
        public HostId HostId { get; private set; }
        public DinnerId DinnerId { get; private set; }
        public Rating Rating { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
        private GuestRating(GuestRatingId guestRatingId, HostId hostId, DinnerId dinnerId, Rating rating)
            : base(guestRatingId)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            Rating = rating;
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
        }

        public static GuestRating Create(HostId hostId, DinnerId dinnerId)
            => new(GuestRatingId.CreateUnique(), hostId, dinnerId, Rating.CreateNew());

#pragma warning disable CS8618
        protected GuestRating()
        {
        }
#pragma warning restore CS8618
    }
}
