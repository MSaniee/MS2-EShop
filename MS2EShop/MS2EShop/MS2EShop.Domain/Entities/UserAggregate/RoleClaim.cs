using Microsoft.AspNetCore.Identity;
using MS2EShop.Domain.Core.Bases;
using System;

namespace MS2EShop.Domain.Entities.UserAggregate
{
    public class RoleClaim : IdentityRoleClaim<Guid>, IEntity
    {
    }
}
