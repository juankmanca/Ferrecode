namespace Ferrecode.Domain.Usuario
{

    public sealed class Usuario
    {
        public Guid ID { get; private set; }
        public Nombre? Nombre { get; private set; }
        public DateTime? FechaEntrada { get; private set; }
        public DateTime? FechaSalida { get; private set; }
        public DateTime? FechaInicioSesion { get; private set; }
        public DateTime? FechaCerroSesion { get; private set; }
        public Guid IDPuntoDeVenta { get; private set; }
        public Username? Username { get; private set; }
        public Password? Password { get; private set; }
        public Usuario()
        {

        }
        public Usuario(Guid iD, Nombre? nombre, DateTime? fechaEntrada, DateTime? fechaSalida, DateTime? fechaInicioSesion, DateTime? fechaCerroSesion, Guid iDPuntoDeVenta, Username? username, Password? password)
        {
            ID = iD;
            Nombre = nombre;
            FechaEntrada = fechaEntrada;
            FechaSalida = fechaSalida;
            FechaInicioSesion = fechaInicioSesion;
            FechaCerroSesion = fechaCerroSesion;
            IDPuntoDeVenta = iDPuntoDeVenta;
            Username = username;
            Password = password;
        }
    }
}
