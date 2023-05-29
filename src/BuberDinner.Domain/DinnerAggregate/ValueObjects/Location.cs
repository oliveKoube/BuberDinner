using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects
{
    public sealed class Location : ValueObject
    {
        public string Name { get; }
        public string Address { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public Location(string name, string address,double latitude,double longitude)
        {
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        public override IEnumerable<object> GetEqualityComponnents()
        {
            yield return new object[] { Name, Address, Latitude, Longitude };
        }
    }
}
