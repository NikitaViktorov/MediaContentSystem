using MediaContentSystem.Domain.Aggregates.ContentAggregates;
using MediaContentSystem.Domain.Aggregates.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaContentSystem.Persistence.Context.EntityConfigurations;

public class ContentEntityConfiguration : IEntityTypeConfiguration<Content>
{
    public void Configure(EntityTypeBuilder<Content> builder)
    {
        builder.ToTable("Contents");

        builder.HasKey(_ => _.Id);
        builder.Ignore(_ => _.DomainEvents);

        builder
            .HasMany(_ => _.Likes)
            .WithOne(_ => _.Content)
            .HasForeignKey(_ => _.ContentId)
            .IsRequired(false);

        builder
            .HasMany(content => content.Users)
            .WithMany(user => user.Contents)
            .UsingEntity<Dictionary<int, int>>("UserContents",
                _ => _.HasOne<User>().WithMany().HasForeignKey("UserId"),
                _ => _.HasOne<Content>().WithMany().HasForeignKey("ContentId"));
    }
}