using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.BillAggregate
{
    public sealed class Bills : AggregateRoot<BillsId, Guid>
    {
        public DinnerId DinnerId { get; }
        public GuestId GuestId { get; }
        public HostId HostId { get; }
        public Price Price { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Bills(BillsId billsId, DinnerId dinnerId, GuestId guestId, HostId hostId,
            Price price)
            : base(billsId)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
            Price = price;
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
        }

        public static Bills Create(DinnerId dinnerId, GuestId guestId, HostId hostId, Price price)
            => new(BillsId.CreateUnique(), dinnerId, guestId, hostId, price);
    }
}
