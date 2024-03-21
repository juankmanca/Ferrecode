using Dapper;
using Ferrecode.Application.Abstractions.Data;
using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Application.Productos.GetProductos;
using Ferrecode.Domain.Abstractions;
using Ferrecode.Domain.Productos;

namespace Ferrecode.Application.Clientes.GetClientes
{
    internal sealed class GetClientesQueryHandler : IQueryHandler<GetClientesQuery, GetClientesResponse>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetClientesQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Result<GetClientesResponse>> Handle(GetClientesQuery request, CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            string sql = """
                SELECT * FROM Clientes
                """;

            var clientes = await connection.QueryAsync<GetClienteResponse>(sql, cancellationToken);


            GetClientesResponse response = new();

            if (clientes is not null && clientes.Any())
            {
                foreach (var item in clientes)
                {
                    response.clientes!.Add(item);
                }
            }


            return response!;
        }
    }
}
