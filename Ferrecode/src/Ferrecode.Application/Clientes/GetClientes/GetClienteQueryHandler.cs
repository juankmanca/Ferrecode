using Dapper;
using Ferrecode.Application.Abstractions.Data;
using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Application.Clientes.GetClientes
{
    internal sealed class GetClienteQueryHandler : IQueryHandler<GetClienteQuery, GetClienteResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetClienteQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<GetClienteResponse>> Handle(GetClienteQuery request, CancellationToken cancellationToken)
        {
            using var conection = _sqlConnectionFactory.CreateConnection();

            string sql = """
                SELECT
                    
                FROM Clientes WHERE ID = @ID
                """;

            var result = await conection.QueryFirstOrDefaultAsync<GetClienteResponse>(sql,
                new
                {
                    request.ID
                }
                );

            return result!;
        }
    }
}
