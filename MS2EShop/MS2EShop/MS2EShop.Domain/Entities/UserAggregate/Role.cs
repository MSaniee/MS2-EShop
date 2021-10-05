using Microsoft.AspNetCore.Identity;
using MS2EShop.Domain.Core.Bases;
using System;
using System.Collections.Generic;

namespace MS2EShop.Domain.Entities.UserAggregate
{
    public class Role : IdentityRole<Guid>, IEntity
    {
        public string Description { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        //public ICollection<PersonnelRole> PersonnelRoles { get; set; }
    }
}
