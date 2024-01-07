using MediaContentSystem.Domain.Aggregates.ContentAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

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
    }
}