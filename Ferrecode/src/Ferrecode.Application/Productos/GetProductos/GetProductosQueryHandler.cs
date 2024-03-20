using Dapper;
using Ferrecode.Application.Abstractions.Data;
using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Application.Productos.GetProductos
{
    internal sealed class GetProductosQueryHandler : IQueryHandler<GetProductosQuery, ProductosResponse>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetProductosQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Result<ProductosResponse>> Handle(GetProductosQuery request, CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            string sql = """
                SELECT 
                	P.ID,
                	P.Nombre,
                	P.Precio, 
                	I.Cantidad 
                  FROM Inventarios I LEFT JOIN Productos P ON P.ID = I.IDProductos 
                  WHERE I.IDPuntoDeVenta = @IDPuntoDeVenta
                """;

            var productos = await connection.QueryAsync<ProductoSQLResponse>(
                    sql,
                    new // Objeto de tipo anonimo
                    {
                        request.IDPuntoDeVenta,
                    }
                );

            ProductosResponse response = new();

            if(productos is not null && productos.Any())
            {
                foreach (var item in productos)
                {
                    response.products!.Add(item);
                }
            }

            return response;
        }
    }
}
