using Ferrecode.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Ferrecode.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async void ApplyMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                //Creamos un log de las migraciones
                var service = scope.ServiceProvider;

                // Creamos un objeto logger factory
                var loggerFactory = service.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = service.GetRequiredService<ApplicationDbContext>();
                    await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    // Mostramos en el log en caso de fallo
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "Error en migracion");
                }
            }
        }
    }
}
