namespace BuberDinner.Domain.Common.Models
{
    public class AggregateRoot<TId, TIdType> : Entity<TId>
        where TId : AggregateRootId<TIdType>
    {
        public new AggregateRootId<TIdType> Id { get; protected set; }
        public AggregateRoot(TId id) : base(id)
        {
        }

#pragma warning disable CS8618
        protected AggregateRoot()
        {
        }
#pragma warning restore CS8618
    }
}
