using EFCoreSecondLevelCacheInterceptor;
using System;
using System.Linq;

namespace MS2EShop.Infrastructure.Data.SqlServer.EfCore.Tools
{
    public static class CacheExtensionsMethod
    {
        public static IQueryable<T> CacheInSecondLevel<T>(this IQueryable<T> query)
        {
            return query.Cacheable(CacheExpirationMode.Sliding, TimeSpan.FromMinutes(5));
        }
    }
}
