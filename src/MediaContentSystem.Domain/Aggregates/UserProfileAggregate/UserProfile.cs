using MediaContentSystem.Domain.Aggregates.UserAggregate;
using MediaContentSystem.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MediaContentSystem.Domain.Aggregates.UserProfileAggregates;

public class UserProfile : Entity, IAggregateRoot
{
    public int? UserId {  get; private set; }
    public User? User { get; private set; } = null!; 

    [MaxLength(100)]
    public string URL { get; private set; } = null!;
}