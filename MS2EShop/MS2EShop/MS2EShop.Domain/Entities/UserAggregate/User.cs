using Microsoft.AspNetCore.Identity;
using MS2EShop.Domain.Core.Bases;
using System;
using System.Collections.Generic;

namespace MS2EShop.Domain.Entities.UserAggregate
{
    public class User : IdentityUser<Guid>, IEntity
    {
        public User()
        {
            SecurityStamp = Guid.NewGuid().ToString();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsActive { get; set; }
        public Address Address { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
