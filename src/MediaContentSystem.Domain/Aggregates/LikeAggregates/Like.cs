using MediaContentSystem.Domain.Aggregates.CommentAggregates;
using MediaContentSystem.Domain.Aggregates.ContentAggregates;
using MediaContentSystem.Domain.Aggregates.UserAggregate;
using MediaContentSystem.Domain.Common;

namespace MediaContentSystem.Domain.Aggregates.LikeAggregates;

public class Like : Entity, IAggregateRoot
{
    public Content? Content { get; private set; } = null!;
    public int? ContentId { get; private set; }

    public Comment? Comment { get; private set; } = null!;
    public int? CommentId { get; private set; }

    public User User { get; set; } = null!;
    public int UserId { get; set; }

    public DateTime LikeDate { get; private set; }
}