using MS2EShop.Domain.Core.Bases;
using MS2EShop.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS2EShop.Domain.Entities.Geography
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public bool IsCentral { get; set; }

        public int ProvinceId { get; set; }
        public Province Province { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
