using Ferrecode.Application.Abstractions.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Ferrecode.Infrastructure.Data
{
    internal sealed class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            // connectamos daper al servicio de base de datos SQLServer
            var connection = new SqlConnection(_connectionString);

            // Abrimos la conexión
            connection.Open();

            // Retornamos la conexión abierta
            return connection;
        }
    }
}
