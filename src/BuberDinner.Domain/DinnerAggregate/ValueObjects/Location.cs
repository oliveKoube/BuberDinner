using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

#pragma warning disable S3453
public sealed class Location : ValueObject
#pragma warning restore S3453
{
    public string Name { get; private set; }
    public string Address { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
#pragma warning disable S1144
    private Location(string name, string address,double latitude,double longitude)
#pragma warning restore S1144
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
