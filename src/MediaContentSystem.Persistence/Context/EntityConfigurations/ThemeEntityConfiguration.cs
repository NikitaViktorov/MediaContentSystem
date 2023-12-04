using MediaContentSystem.Domain.Aggregates.ThemeAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaContentSystem.Persistence.Context.EntityConfigurations;

public class ThemeEntityConfiguration : IEntityTypeConfiguration<Theme>
{
    public void Configure(EntityTypeBuilder<Theme> builder)
    {
        builder.ToTable("Themes");

        builder.HasKey(_ => _.Id);
        builder.Ignore(_ => _.DomainEvents);

        builder
            .HasMany(_ => _.Users)
            .WithMany(_ => _.Themes)
            .UsingEntity("UserThemes");
    }
}