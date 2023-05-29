using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        public float Value { get; private set; }

        private Rating(float value)
        {
            Value = value;
        }

        public static Rating CreateNew(float value = 0) => new(value);

        public override IEnumerable<object> GetEqualityComponnents()
        {
            yield return Value;
        }
    }
}
