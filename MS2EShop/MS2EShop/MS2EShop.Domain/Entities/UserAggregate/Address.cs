using MS2EShop.Domain.Core.Bases;
using MS2EShop.Domain.Entities.Geography;
using NetTopologySuite.Geometries;
using System.Collections.Generic;

namespace MS2EShop.Domain.Entities.UserAggregate
{
    public class Address : ValueObject
    {
        public string Description { get; private set; }
        public long Lat { get; private set; }
        public long Long { get; private set; }

        public Point Location { get; private set; }

        public int CityId { get; private set; }
        public City City { get; private set; }

        private Address() { }

        public Address(string description, long lat, long @long, Point location, int cityId)
        {
            Description = description;
            Lat = lat;
            Long = @long;
            Location = location;
            CityId = cityId;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Description;
            yield return Lat;
            yield return Long;
            yield return Location;
            yield return CityId;
            yield return City;
        }
    }
}
