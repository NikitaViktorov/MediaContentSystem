using MediaContentSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MediaContentSystemContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("MediaContentSystemConnectionString"),
    opts => opts.MigrationsAssembly("MediaContentSystem.Persistence.Migrations")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();