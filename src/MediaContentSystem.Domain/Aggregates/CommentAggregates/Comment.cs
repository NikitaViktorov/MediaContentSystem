using MediaContentSystem.Domain.Aggregates.UserAggregate;
using MediaContentSystem.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MediaContentSystem.Domain.Aggregates.CommentAggregates;

public class Comment : Entity, IAggregateRoot
{
    public int? AnsweredCommentId { get; private set; }
    public Comment AnsweredComment { get; private set; } = null!;

    public int UserId {  get; private set; }
    public User User { get; private set; } = null!; 

    [MaxLength(1000)]
    public string Text { get; private set; } = null!;
}