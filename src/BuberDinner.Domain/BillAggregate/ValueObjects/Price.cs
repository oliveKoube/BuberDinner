using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.BillAggregate.ValueObjects
{
    public sealed class Price : ValueObject
    {
        public float Amount { get; private set; }
        public string Currency { get; private set; }
        private Price(float amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Price CreateNew(float amount = 0, string currency = "") => new(amount, currency);

        public override IEnumerable<object> GetEqualityComponnents()
        {
            yield return new object[] { Amount, Currency };
        }
    }
}