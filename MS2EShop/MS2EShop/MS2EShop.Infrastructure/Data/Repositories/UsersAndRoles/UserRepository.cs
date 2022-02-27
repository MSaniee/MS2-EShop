using Mapster;
using Microsoft.EntityFrameworkCore;
using MS2EShop.Application.Interfaces.Repositories.UsersAndRoles;
using MS2EShop.Common.StringTools;
using MS2EShop.Domain.Core.DILifeTimesType;
using MS2EShop.Domain.Core.Utilities.PagesSettings;
using MS2EShop.Domain.Entities.UserAggregate;
using MS2EShop.Infrastructure.Data.SqlServer.EfCore.Context;
using MS2EShop.Infrastructure.Data.SqlServer.EfCore.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MS2EShop.Infrastructure.Data.Repositories.UsersAndRoles;
public class UserRepository : Repository<User>, IUserRepository, IScopedDependency
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task<List<T>> GetAllUser<T>(Pagable pagable, CancellationToken cancellationToken)
    {
        IQueryable<User> query = TableNoTracking;

        if (pagable.Search.HasValue())
            query = query.Where(u => u.FirstName.Contains(pagable.Search) ||
                    u.LastName.Contains(pagable.Search) ||
                    u.PhoneNumber.Contains(pagable.Search));

        return query.OrderByDescending(u => u.RegisterDate)
                    .ToPaged(pagable)
                    .CacheInSecondLevel()
                    .ProjectToType<T>()
                    .ToListAsync(cancellationToken);
    }

    public Task<List<T>> GetAllUser<T>(Expression<Func<User, T>> mappingSelector, Pagable pagable, CancellationToken cancellationToken)
    {
        if (pagable.Search.HasValue())
        {
            Table.Where(u => u.FirstName.Contains(pagable.Search) ||
                             u.LastName.Contains(pagable.Search) ||
                             u.PhoneNumber.Contains(pagable.Search));
        }

        return Table.OrderByDescending(u => u.RegisterDate)
                    .Skip((pagable.Page - 1) * pagable.PageSize)
                    .Take(pagable.PageSize)
                    .Select(mappingSelector)
                    .ToListAsync(cancellationToken);
    }

    public Task<int> GetUsersNumber(CancellationToken cancellationToken)
    {
        return TableNoTracking.CacheInSecondLevel().CountAsync(cancellationToken);
    }

    public Task<bool> UserExists(string phoneNumber, string userName, CancellationToken cancellationToken)
    {
        return TableNoTracking
            .AnyAsync(u => u.PhoneNumber == phoneNumber || u.UserName == userName,
             cancellationToken);
    }
}

