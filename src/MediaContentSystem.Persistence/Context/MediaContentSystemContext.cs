using System.Reflection;
using MediaContentSystem.Domain.Aggregates.CommentAggregates;
using MediaContentSystem.Domain.Aggregates.ContentAggregates;
using MediaContentSystem.Domain.Aggregates.LikeAggregates;
using MediaContentSystem.Domain.Aggregates.UserAggregate;
using MediaContentSystem.Domain.Aggregates.UserProfileAggregates;
using Microsoft.EntityFrameworkCore;

namespace MediaContentSystem.Persistence.Context;

public class MediaContentSystemContext : DbContext
{
    public MediaContentSystemContext(DbContextOptions<MediaContentSystemContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>();
        modelBuilder.Entity<Content>();
        modelBuilder.Entity<Like>();
        modelBuilder.Entity<User>();
        modelBuilder.Entity<UserProfile>(); 

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}