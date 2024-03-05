namespace Ferrecode.Domain.Abstractions
{
    public abstract class Concepto
    {
        public Guid ID { get; init; }
        public string? Nombre { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaActualizacion { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = new();

        public Concepto()
        {

        }

        protected Concepto(Guid iD, string? nombre, DateTime fechaCreacion, DateTime fechaActualizacion)
        {
            ID = iD;
            Nombre = nombre;
            FechaCreacion = fechaCreacion;
            FechaActualizacion = fechaActualizacion;
        }
        public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
