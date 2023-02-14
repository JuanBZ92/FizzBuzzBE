using FizzBuzz.Services;

namespace FizzBuzz.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFizzBuzzService, FizzBuzzService>();

            return services;
        }
    }
}
