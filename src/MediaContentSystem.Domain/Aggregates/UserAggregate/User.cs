using System.ComponentModel.DataAnnotations;
using MediaContentSystem.Domain.Common;

namespace MediaContentSystem.Domain.Aggregates.UserAggregate;

public class User : Entity, IAggregateRoot
{
    [MaxLength(50)]
    public string Name { get; private set; } = null!;

    [MaxLength(50)] 
    public string Surname { get; private set; } = null!;
    
    public DateTime Birthday { get; private set; } 
    
    [MaxLength(250)] 
    public string Email { get; private set; } = null!;
    
    public bool IsAdmin { get; private set; }
}