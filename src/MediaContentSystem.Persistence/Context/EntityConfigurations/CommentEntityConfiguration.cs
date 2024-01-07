using MediaContentSystem.Domain.Aggregates.CommentAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaContentSystem.Persistence.Context.EntityConfigurations;

public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");

        builder.HasKey(_ => _.Id);
        builder.Ignore(_ => _.DomainEvents);

        builder
            .HasMany(_ => _.Likes)
            .WithOne(_ => _.Comment)
            .HasForeignKey(_ => _.CommentId)
            .IsRequired(false);
    }
}