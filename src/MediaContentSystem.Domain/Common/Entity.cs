namespace MediaContentSystem.Domain.Common;

public class Entity
{
    private int _id;
    private List<DomainEvent>? _domainEvents;

    public virtual int Id
    {
        get => _id;
        protected set => _id = value;
    }

    public IReadOnlyCollection<DomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(DomainEvent eventItem)
    {
        if (_domainEvents is null)
            _domainEvents = new List<DomainEvent>();

        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(DomainEvent eventItem) => _domainEvents?.Remove(eventItem);

    public void ClearDomainEvents() => _domainEvents?.Clear();
}