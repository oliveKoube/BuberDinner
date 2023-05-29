using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities
{
    public sealed class DinnerReservation : Entity<DinnerReservartionId>
    {
        public int GuestCount { get; }
        public string ReservationStatus { get; }
        public GuestId GuestId { get; }
        public DateTime? ArrivalDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        private DinnerReservation(DinnerReservartionId dinnerReservartionId,int guestCount, string reservationStatus,
            GuestId guestId, DateTime? arrivalDateTime)
            : base(dinnerReservartionId)
        {
            GuestCount = guestCount;
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            ArrivalDateTime = arrivalDateTime;
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
        }

        public static DinnerReservation Create(int guestCount, string reservationStatus, GuestId guestId,
            DateTime? arrivalDateTime) 
            => new(DinnerReservartionId.CreateUnique(), guestCount, reservationStatus,guestId,null);
    }
}
