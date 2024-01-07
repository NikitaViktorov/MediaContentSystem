using MediaContentSystem.Domain.Aggregates.LikeAggregates;
using MediaContentSystem.Domain.Aggregates.UserAggregate;
using MediaContentSystem.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaContentSystem.Domain.Aggregates.ContentAggregates;

public class Content : Entity, IAggregateRoot
{
    private List<Like> _likes;
    private List<User> _users;

    public Content()
    {
        _likes = new List<Like>();
        _users = new List<User>();
    }

    [MaxLength(200)]
    public string LinkReference { get; private set; } = null!;

    [Column(TypeName = "nvarchar(11)")]
    public ContentType ContentType { get; private set; }

    public virtual IReadOnlyCollection<Like> Likes => _likes.AsReadOnly();

    public virtual IReadOnlyCollection<User> Users => _users.AsReadOnly();
}