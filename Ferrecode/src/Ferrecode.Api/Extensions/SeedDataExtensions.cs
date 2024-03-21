using Bogus;
using Dapper;
using Ferrecode.Application.Abstractions.Data;
using Ferrecode.Domain.Productos;
using System.Data;
using System.Globalization;

namespace Ferrecode.Api.Extensions
{
    public class ObjectsToSave
    {
        public List<object>? Items { get; set; }
        public string sql { get; set; } = string.Empty;
    }

    public static class SeedDataExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            //Conexion con la cual esta trabajando Dapper
            var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();

            using var connection = sqlConnectionFactory.CreateConnection();

            //CreateProducts(connection);
            CreatePuntoDeVenta(connection);
            CreateTiposDeDocumento(connection);
        }

        private static void CreateTiposDeDocumento(IDbConnection connection)
        {
            string sql = """
                INSERT INTO TiposDeDocumento (
                    Nombre,
                    Acronimo)
                VALUES 
                    ('Cedula De Ciudadanía', 'CC'),
                    ('Cedula De Extranjeria', 'CE'),
                    ('Pasaporte', 'PP'),
                    ('NIT', 'NIT')
                """;
            connection.Execute(sql);
        }

        private static void CreatePuntoDeVenta(IDbConnection connection)
        {
            var faker = new Faker();

            List<object> puntosDeVenta = new();

            puntosDeVenta.Add(new
            {
                ID = Guid.NewGuid(),
                Nombre = faker.Commerce.ProductName(),
                FechaCreacion = DateTime.UtcNow,
                FechaActualizacion = DateTime.UtcNow
            });

            const string sql = """
                INSERT INTO [dbo].[PuntosDeVenta]
                      ([ID]
                      ,[Nombre]
                      ,[FechaCreacion]
                      ,[FechaActualizacion])
                VALUES
                      (
                      @ID,
                        @Nombre,
                        @FechaCreacion,
                        @FechaActualizacion
                      )
                """;

            connection.Execute(sql, puntosDeVenta);
        }

        private static void CreateProducts(IDbConnection connection)
        {
            var faker = new Faker();

            List<object> productos = new();

            for (var i = 0; i < 50; i++)
            {
                productos.Add(new
                {
                    ID = Guid.NewGuid(),
                    Nombre = faker.Commerce.ProductName(),
                    FechaCreacion = DateTime.UtcNow,
                    FechaActualizacion = DateTime.UtcNow,
                    Precio = decimal.Parse(faker.Commerce.Price(1, 500000), CultureInfo.InvariantCulture),
                    ValorMedida = decimal.Parse(faker.Commerce.Price(1, 50), CultureInfo.InvariantCulture),
                    Peso = decimal.Parse(faker.Commerce.Price(1, 50), CultureInfo.InvariantCulture),
                    VolumenEmpaque = decimal.Parse(faker.Commerce.Price(1, 100), CultureInfo.InvariantCulture),
                    UnidadDeMedida = "mt"
                });
            }

            const string sql = """
                INSERT INTO [dbo].[Productos]
                      ([ID]
                      ,[Precio]
                      ,[ValorMedida]
                      ,[UnidadDeMedida]
                      ,[Peso]
                      ,[VolumenEmpaque]
                      ,[Nombre]
                      ,[FechaCreacion]
                      ,[FechaActualizacion])
                VALUES
                      (
                        @ID,
                        @Precio,
                        @ValorMedida,
                        @UnidadDeMedida,
                        @Peso,
                        @VolumenEmpaque,
                        @Nombre,
                        @FechaCreacion,
                        @FechaActualizacion
                      ) 
                """;

            connection.Execute(sql, productos);

        }

    }
}
