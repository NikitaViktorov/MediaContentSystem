﻿using System.ComponentModel.DataAnnotations;
using MediaContentSystem.Domain.Aggregates.CommentAggregates;
using MediaContentSystem.Domain.Aggregates.ContentAggregates;
using MediaContentSystem.Domain.Aggregates.LikeAggregates;
using MediaContentSystem.Domain.Aggregates.UserProfileAggregates;
using MediaContentSystem.Domain.Common;

namespace MediaContentSystem.Domain.Aggregates.UserAggregate;

public class User : Entity, IAggregateRoot
{
    private List<Comment> _comments;
    private List<Content> _contents;
    private List<Like> _likes;
    private List<UserProfile> _userProfiles;

    private User()
    {
        _comments = new List<Comment>();
        _contents = new List<Content>();
        _likes = new List<Like>();
        _userProfiles = new List<UserProfile>();
    }

    [MaxLength(50)]
    public string Name { get; private set; } = null!;

    [MaxLength(50)] 
    public string Surname { get; private set; } = null!;
    
    public DateTime Birthday { get; private set; } 
    
    [MaxLength(250)] 
    public string Email { get; private set; } = null!;

    [MaxLength(50)]
    public string Password { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public bool IsAdmin { get; private set; }

    public virtual IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    public virtual IReadOnlyCollection<Content> Contents => _contents.AsReadOnly();

    public virtual IReadOnlyCollection<Like> Likes => _likes.AsReadOnly();

    public virtual IReadOnlyCollection<UserProfile> UserProfiles => _userProfiles.AsReadOnly();
}