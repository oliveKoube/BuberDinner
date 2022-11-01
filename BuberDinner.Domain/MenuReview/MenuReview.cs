﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.MenuReview
{
    public sealed class MenuReview : AggregateRoot<MenuReviewId>
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
            GuestId guestId, DinnerId dinnerId, DateTime createdDateTime, DateTime updatedDateTime)
            : base(menuReviewId)
        {
            Rating = rating;
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static MenuReview Create(Rating rating, string comment, HostId hostId, MenuId menuId,
            GuestId guestId, DinnerId dinnerId)
            => new(MenuReviewId.CreateUnique(), rating, comment, hostId, menuId, 
                guestId, dinnerId, DateTime.UtcNow, DateTime.UtcNow);
    }
}
