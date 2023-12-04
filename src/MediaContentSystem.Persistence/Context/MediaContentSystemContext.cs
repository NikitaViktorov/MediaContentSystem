﻿using System.Reflection;
using MediaContentSystem.Domain.Aggregates.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace MediaContentSystem.Persistence.Context;

public class MediaContentSystemContext : DbContext
{
    public MediaContentSystemContext(DbContextOptions<MediaContentSystemContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>();

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}