using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuReviewAggregate
{
    public sealed class MenuReview : AggregateRoot<MenuReviewId, Guid>
    {
        public Rating Rating { get; set; }
        public string Comment { get; set; }
        public HostId HostId { get; set; }
        public MenuId MenuId { get; set; }
        public GuestId GuestId { get; set; }
        public DinnerId DinnerId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        private MenuReview(MenuReviewId menuReviewId, Rating rating, string comment, HostId hostId, MenuId menuId, 
            GuestId guestId, DinnerId dinnerId)
            : base(menuReviewId)
        {
            Rating = rating;
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
        }

        public static MenuReview Create(Rating rating, string comment, HostId hostId, MenuId menuId,
            GuestId guestId, DinnerId dinnerId)
            => new(MenuReviewId.CreateUnique(), rating, comment, hostId, menuId, 
                guestId, dinnerId);
    }
}
