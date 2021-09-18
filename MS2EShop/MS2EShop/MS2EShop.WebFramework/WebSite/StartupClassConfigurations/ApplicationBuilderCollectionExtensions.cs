using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace MS2EShop.WebFramework.WebSite.StartupClassConfigurations
{
    public static class ApplicationBuilderCollectionExtensions
    {
        public static void UseWebSiteEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
