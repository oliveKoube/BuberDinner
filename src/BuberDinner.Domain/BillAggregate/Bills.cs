using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.BillAggregate
{
    public sealed class Bills : AggregateRoot<BillsId, Guid>
    {
        public DinnerId DinnerId { get; private set; }
        public GuestId GuestId { get; private set; }
        public HostId HostId { get; private set; }
        public Price Price { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

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

        public static Bills Create(DinnerId dinnerId, GuestId guestId, HostId hostId)
            => new(BillsId.CreateUnique(), dinnerId, guestId, hostId, Price.CreateNew());

#pragma warning disable CS8618
        public Bills()
        {
        }
#pragma warning restore CS8618
    }
}
