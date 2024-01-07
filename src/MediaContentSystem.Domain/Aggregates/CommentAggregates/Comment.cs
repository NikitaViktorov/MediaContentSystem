using MediaContentSystem.Domain.Aggregates.LikeAggregates;
using MediaContentSystem.Domain.Aggregates.UserAggregate;
using MediaContentSystem.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MediaContentSystem.Domain.Aggregates.CommentAggregates;

public class Comment : Entity, IAggregateRoot
{
    private List<Like> _likes;

    public Comment()
    {
        _likes = new List<Like>();
    }

    public int? AnsweredCommentId { get; private set; }
    public Comment AnsweredComment { get; private set; } = null!;

    public int UserId {  get; private set; }
    public User User { get; private set; } = null!; 

    [MaxLength(1000)]
    public string Text { get; private set; } = null!;

    public DateTime CommentDate { get; private set; }

    public virtual IReadOnlyCollection<Like> Likes => _likes.AsReadOnly();
}