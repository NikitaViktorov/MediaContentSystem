using MediaContentSystem.Domain.Aggregates.UserAggregate;
using MediaContentSystem.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MediaContentSystem.Domain.Aggregates.ThemeAggregates;

public class Theme : Entity, IAggregateRoot
{
    private List<User> _users;

    private Theme()
    {
        _users = new();
    }

    [MaxLength(50)]
    public string Title { get; set; } = null!;

    public virtual IReadOnlyCollection<User> Users => _users.AsReadOnly();
}