namespace BuberDinner.Domain.Common.Models
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetEqualityComponnents();

        public override bool Equals(object? obj)
        {
            if(obj is null || obj.GetType() != GetType())
            {
                return false;
            }
            var valueObject = (ValueObject)obj;

            return GetEqualityComponnents()
                .SequenceEqual(valueObject.GetEqualityComponnents());
        }

        public static bool operator ==(ValueObject left, ValueObject right) => Equals(left, right);
        public static bool operator !=(ValueObject left, ValueObject right) => !Equals(left, right);
        public override int GetHashCode() => GetEqualityComponnents()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x ^ y);

        public bool Equals(ValueObject? other) => Equals((object?)other);
    }
}
