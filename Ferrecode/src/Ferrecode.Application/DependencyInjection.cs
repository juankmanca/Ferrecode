using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Ferrecode.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            // services.AddTransient(IInventoryRepository, )

            return services;
        }
    }
}
