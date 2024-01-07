using MediaContentSystem.Domain.Aggregates.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaContentSystem.Persistence.Context.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(_ => _.Id);
        builder.Ignore(_ => _.DomainEvents);

        builder
            .HasMany(_ => _.Comments)
            .WithOne(_ => _.User)
            .HasForeignKey(_ => _.UserId);

        builder
            .HasMany(_ => _.Contents)
            .WithMany(_ => _.Users)
            .UsingEntity("UserContents");

        builder
            .HasMany(_ => _.Likes)
            .WithOne(_ => _.User)
            .HasForeignKey(_ => _.UserId);
    }
}