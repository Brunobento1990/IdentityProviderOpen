using Api.Configuracoes;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureController()
    .ConfigureSwagger()
    .AddRepositories()
    .AddContext(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

if (builder.Configuration["AddSwagger"]?.ToUpper() == "TRUE")
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseAuthorization();

app.UseCors("base");

app.MapControllers();

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