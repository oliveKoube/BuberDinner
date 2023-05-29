using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class AverageRating : ValueObject
    {
        public double Value { get; private set; }
        public int NumRatings { get; private set; }

        private AverageRating(double value, int numRatings)
        {
            Value = value;
            NumRatings = numRatings;
        }

        public static AverageRating CreateNew(double rating = 0, int numRating = 0) => new(rating, numRating);

        public void AddNewRating(Rating rating) => Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
        public void RemoveRating(Rating rating) => Value = ((Value * NumRatings) - rating.Value) / --NumRatings;

        public override IEnumerable<object> GetEqualityComponnents()
        {
            yield return Value; 
        }
    }
}
