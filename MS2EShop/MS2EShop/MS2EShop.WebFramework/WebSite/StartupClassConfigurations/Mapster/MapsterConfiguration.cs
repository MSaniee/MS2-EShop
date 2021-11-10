using Mapster;
using Microsoft.Extensions.DependencyInjection;
using MS2EShop.Application.Dtos;

namespace MS2EShop.WebFramework.WebSite.StartupClassConfigurations.Mapster
{
    public static class MapsterConfiguration
    {
        public static void AddMapster(this IServiceCollection services)
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            // scans the assembly and gets the IRegister, adding the registration to the TypeAdapterConfig
            typeAdapterConfig.Scan(typeof(BaseDto<,>).Assembly);
        }
    }
}
