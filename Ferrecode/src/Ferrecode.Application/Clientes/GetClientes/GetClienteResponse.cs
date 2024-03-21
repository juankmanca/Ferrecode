using Ferrecode.Domain.Clientes;

namespace Ferrecode.Application.Clientes.GetClientes
{
    public class GetClienteResponse
    {
        public string? Nombre { get; set; }
        public string NumeroDocumento { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
