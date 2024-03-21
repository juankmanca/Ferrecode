using Ferrecode.Application.Abstractions.Clock;
using Ferrecode.Application.Abstractions.Data;
using Ferrecode.Domain.Abstractions;
using Ferrecode.Domain.Clientes;
using Ferrecode.Domain.Inventarios;
using Ferrecode.Domain.Productos;
using Ferrecode.Domain.PuntosDeVenta;
using Ferrecode.Infrastructure.Clock;
using Ferrecode.Infrastructure.Data;
using Ferrecode.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ferrecode.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            var connectionString = configuration.GetConnectionString("Database") ?? throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IInventarioRepository, InventarioRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPuntoDeVentaRepository, PuntoDeVentaRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

            return services;
        }
    }
}
