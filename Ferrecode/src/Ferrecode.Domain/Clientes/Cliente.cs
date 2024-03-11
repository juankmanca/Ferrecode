using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Clientes
{
    public sealed class Cliente : Concepto
    {
        public Documento? Documento { get; private set; }
        public Direccion? Direccion { get; private set; }
        public Email? Email { get; private set; }
        public Cliente()
        {

        }

        public Cliente(Guid iD, string? nombre, DateTime fechaCreacion, DateTime fechaActualizacion,
            Documento? documento, Direccion? direccion, Email? email) : base(iD, nombre, fechaCreacion, fechaActualizacion)
        {
            Documento = documento;
            Direccion = direccion;
            Email = email;
        }

    }
}
