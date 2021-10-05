using Microsoft.AspNetCore.Identity;
using MS2EShop.Domain.Core.Bases;
using System;

namespace MS2EShop.Domain.Entities.UserAggregate
{
    public class UserRole : IdentityUserRole<Guid>, IEntity
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
