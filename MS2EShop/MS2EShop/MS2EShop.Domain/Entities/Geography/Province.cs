using MS2EShop.Domain.Core.Bases;
using System.Collections.Generic;

namespace MS2EShop.Domain.Entities.Geography
{
    public class Province : BaseEntity
    {
        public string Name { get; set; }
        public string CentralCityName { get; set; }

        public ICollection<City> Citites { get; set; }
    }
}
