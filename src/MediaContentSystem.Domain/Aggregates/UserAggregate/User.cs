using System.ComponentModel.DataAnnotations;
using MediaContentSystem.Domain.Aggregates.ThemeAggregates;
using MediaContentSystem.Domain.Common;

namespace MediaContentSystem.Domain.Aggregates.UserAggregate;

public class User : Entity, IAggregateRoot
{
    private List<Theme> _themes;

    private User()
    {
        _themes = new();
    }

    [MaxLength(50)]
    public string Name { get; private set; } = null!;

    [MaxLength(50)] 
    public string Surname { get; private set; } = null!;
    
    public DateTime Birthday { get; private set; } 
    
    [MaxLength(250)] 
    public string Email { get; private set; } = null!;

    public bool IsAdmin { get; private set; }

    public virtual IReadOnlyCollection<Theme> Themes => _themes.AsReadOnly();
}