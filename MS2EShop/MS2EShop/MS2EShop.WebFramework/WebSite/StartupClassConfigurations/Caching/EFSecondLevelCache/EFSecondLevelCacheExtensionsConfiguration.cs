using EFCoreSecondLevelCacheInterceptor;
using Microsoft.Extensions.DependencyInjection;

namespace MS2EShop.WebFramework.WebSite.StartupClassConfigurations.EFSecondLevelCache
{
    public static class EFSecondLevelCacheExtensionsConfiguration
    {
        public static void AddCustomEFSecondLevelCache(this IServiceCollection services)
        {
            const string providerName1 = "InMemory1";
            services.AddEFSecondLevelCache(options =>
                    options.UseEasyCachingCoreProvider(providerName1, isHybridCache: false).DisableLogging(true).UseCacheKeyPrefix("EF_")
            );
        }
    }
}
