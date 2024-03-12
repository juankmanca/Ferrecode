using Ferrecode.Application.Abstractions.Behaviors;
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
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            // añade todas las reglas de validacion ej namespace Ferrecode.Application.Productos.CreateProducto
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            // services.AddTransient(IInventoryRepository, )

            return services;
        }
    }
}
