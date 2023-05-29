using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.Common.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate.Entities
{
    public sealed class GuestRating : Entity<GuestRatingId>
    {
        public HostId HostId { get; set; }
        public DinnerId DinnerId { get; set; }
        public Rating Rating { get; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        private GuestRating(GuestRatingId guestRatingId, HostId hostId, DinnerId dinnerId, Rating rating)
            : base(guestRatingId)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            Rating = rating;
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
        }

        public static GuestRating Create(HostId hostId, DinnerId dinnerId, Rating rating) 
            => new(GuestRatingId.CreateUnique(), hostId, dinnerId, rating);
    }
}
