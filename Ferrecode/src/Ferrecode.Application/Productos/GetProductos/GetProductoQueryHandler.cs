using Dapper;
using Ferrecode.Application.Abstractions.Data;
using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Application.Productos.GetProductos
{
    internal sealed class GetProductoQueryHandler : IQueryHandler<GetProductoQuery, ProductoResponse>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetProductoQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Result<ProductoResponse>> Handle(GetProductoQuery request, CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            string sql = """
                SELECT 
                    ID,
                    Nombre,
                    Precio
                FROM Productos WHERE ID = @IDProducto
                """;

            var producto = await connection.QueryFirstOrDefaultAsync<ProductoResponse>(
                    sql,
                    new // Objeto de tipo anonimo
                    {
                        request.IDProducto,
                    }
                );

            return producto!;
        }
    }
}
