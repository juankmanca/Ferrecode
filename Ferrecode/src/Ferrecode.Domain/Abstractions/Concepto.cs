namespace Ferrecode.Domain.Abstractions
{
    public abstract class Concepto : Entity
    {
        protected Concepto(): base() { }

        public string? Nombre { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaActualizacion { get; private set; }

        protected Concepto(Guid ID, string? nombre, DateTime fechaCreacion, DateTime fechaActualizacion) : base(ID)
        {
            Nombre = nombre;
            FechaCreacion = fechaCreacion;
            FechaActualizacion = fechaActualizacion;
        }
    }
}
