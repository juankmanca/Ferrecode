using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Clientes
{
    public sealed class Cliente : Concepto
    {
        public Documento? Documento { get; private set; }
        public Direccion? Direccion { get; private set; }
        public Email? Email { get; private set; }
        public Guid IDPuntoDeVenta { get; private set; }

        private Cliente() { }

        private Cliente(Guid iD, string? nombre, DateTime fechaCreacion, DateTime fechaActualizacion,
            Documento? documento, Direccion? direccion, Email? email, Guid iDPuntoDeVenta) : base(iD, nombre, fechaCreacion, fechaActualizacion)
        {
            Documento = documento;
            Direccion = direccion;
            Email = email;
            IDPuntoDeVenta = iDPuntoDeVenta;
        }

        public static Cliente Create(string? nombre, Documento? documento, Direccion? direccion, Email? email, Guid IDPuntoDeVenta)
        {
            return new Cliente(
                Guid.NewGuid(),
                nombre,
                DateTime.UtcNow,
                DateTime.UtcNow,
                documento,
                direccion,
                email,
                IDPuntoDeVenta
                );
        }

        public void Update(string? nombre, Documento? documento, Direccion? direccion, Email? email)
        {
            Nombre = nombre;
            Documento = documento;
            Direccion = direccion;
            Email = email;
            FechaActualizacion = DateTime.UtcNow;
        }
    }
}
