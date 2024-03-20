namespace Ferrecode.Domain.Abstractions
{
    public abstract class Concepto : Entity
    {
        protected Concepto(): base() { }

        public string? Nombre { get; set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaActualizacion { get; set; }
        public bool Status { get; set; }

        protected Concepto(Guid ID, string? nombre, DateTime fechaCreacion, DateTime fechaActualizacion, bool status = true) : base(ID)
        {
            Nombre = nombre;
            FechaCreacion = fechaCreacion;
            FechaActualizacion = fechaActualizacion;
            Status = status;
        }
    }
}
