using MS2EShop.Domain.Core.Utilities.PagesSettings;
using MS2EShop.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MS2EShop.Application.Interfaces.Repositories.UsersAndRoles
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<T>> GetAllUser<T>(Pagable pagable, CancellationToken cancellationToken);
        Task<List<T>> GetAllUser<T>(Expression<Func<User, T>> mappingSelector, Pagable pagable, CancellationToken cancellationToken);
    }
}
