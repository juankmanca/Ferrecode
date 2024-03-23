using Ferrecode.Domain.Clientes;

namespace Ferrecode.Api.Controllers.Clientes
{
    public class CreateClienteRequest
    {
        public string? Nombre { get; set; }

        public string Telefono { get; set; } = string.Empty;
        
        //Documento
        public string NumeroDocumento { get; set; } = string.Empty;
        public TiposDeDocumento TipoDocumento { get; set; }
        
        //Direccion
        public string Direccion { get; set; } = string.Empty;
        public int IDCiudad { get; set; }
        public int IDDepartamento { get; set; }
        
        public string Email { get; set; } = string.Empty;

        public Guid IDPuntoDeVenta { get; set; }
    }
}
