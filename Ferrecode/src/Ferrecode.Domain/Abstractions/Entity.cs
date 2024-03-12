namespace Ferrecode.Domain.Abstractions
{
    public abstract class Entity
    {
        public Guid ID { get; init; }

        private readonly List<IDomainEvent> _domainEvents = new();

        protected Entity(Guid iD)
        {
            ID = iD;
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
