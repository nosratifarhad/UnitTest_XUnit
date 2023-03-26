using UnitTestUsingXUnit.Business;
using UnitTestUsingXUnit.DataAccess;

namespace UnitTestUsingXUnit.Api.IOC
{
    public static class ServiceRegister
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
