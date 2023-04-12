using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.UnitTest
{
    public class IntegrationTestsFixture : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureTestServices(servicesConfiguration =>
            {
                // TODO: Figure this out
                // See also: https://stackoverflow.com/q/55599360/419956
                //servicesConfiguration.AddScoped<IProductService>(di
                //    => new DecoratedBarService(Server.Host.Services.GetRequiredService<IBarService>()));
            });
        }
    }
}
