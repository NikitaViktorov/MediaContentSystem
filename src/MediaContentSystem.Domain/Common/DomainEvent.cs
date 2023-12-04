using MediatR;

namespace MediaContentSystem.Domain.Common;

public class DomainEvent : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}