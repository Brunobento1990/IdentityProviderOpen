using Infrastructure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddContext(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

_ = Task.Run(async () =>
{
    try
    {
        if (builder.Configuration["RodarMigration"]?.ToUpper() != "TRUE")
        {
            return;
        }

        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetService<AppDbContext>();
        if (db != null)
        {
            await db.Database.MigrateAsync();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
    }
});

app.Run();