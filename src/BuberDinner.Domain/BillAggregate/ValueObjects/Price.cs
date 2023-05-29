using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.BillAggregate.ValueObjects
{
    public sealed class Price : ValueObject
    {
        public float Amount { get; }
        public string Currency { get; }
        public Price(float amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override IEnumerable<object> GetEqualityComponnents()
        {
            yield return new object[] { Amount, Currency };
        }
    }
}
