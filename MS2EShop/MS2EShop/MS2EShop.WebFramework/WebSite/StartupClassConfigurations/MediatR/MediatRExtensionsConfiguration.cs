using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MS2EShop.Application.Dtos;

namespace MS2EShop.WebFramework.WebSite.StartupClassConfigurations.MediatR
{
    public static class MediatRExtensionsConfiguration
    {
        public static void AddCustomMediatR(this IServiceCollection services)
        {
            var assembly = typeof(BaseDto<,>).Assembly;
            services.AddMediatR(assembly);

        }
    }
}
