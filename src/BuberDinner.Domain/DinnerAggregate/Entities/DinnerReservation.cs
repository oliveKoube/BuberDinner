using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities
{
    public sealed class DinnerReservation : Entity<DinnerReservartionId>
    {
        public int GuestCount { get; private set; }
        public string ReservationStatus { get; private set; }
        public GuestId GuestId { get; private set; }
        public DateTime? ArrivalDateTime { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
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

#pragma warning disable CS8618
        protected DinnerReservation()
        {
        }
#pragma warning restore CS8618
    }
}
