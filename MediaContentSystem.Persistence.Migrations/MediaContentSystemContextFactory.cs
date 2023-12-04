using MediaContentSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace MediaContentSystem.Persistence.Migrations;

public class MediaContentSystemContextFactory : IDesignTimeDbContextFactory<MediaContentSystemContext>
{
    public MediaContentSystemContext CreateDbContext(string[] args)
    {
        var connStr = "Server=localhost\\SQLEXPRESS;Initial Catalog=MediaContentSystemDb;Trusted_Connection=True;TrustServerCertificate=True;";

        if (args is not null && args.Length > 0 && args[0].StartsWith("Server="))
            connStr = args[0][5..];

        var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

        var optionsBuilder = new DbContextOptionsBuilder<MediaContentSystemContext>();

        optionsBuilder.UseSqlServer(connStr, opts => opts.MigrationsAssembly(assemblyName).MigrationsHistoryTable("__EFMigrationsHistory"));

        return new MediaContentSystemContext(optionsBuilder.Options);
    }
}