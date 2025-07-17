using Core.Database.Abstraction;
using Core.Database.Concrete;
using Core.Extensions.DbHostExtension;
using Core.Utilities.Mediator.Abstract;
using Core.Utilities.Mediator.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence.Data.HrsDbContext;
using WebApi.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
});


// Mediator
builder.Services.AddScoped<IMediator, CustomMediator>();

builder.Services.AddDbContext<HrsUserDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql")));
builder.Services.AddScoped<IEfCoreDbInitializer, EfCoreDbInitializer>();

builder.Services.AddProjectServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});




var app = builder.Build();


app.UseCors("AllowAll");
app.MapGet("api/Test/", () => "Hello, World!");

//Generet db if not exist
await app.UseEfCoreDbInitializerAsync<HrsUserDbContext>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API v1");
        options.RoutePrefix = string.Empty; // Swagger UI root'ta olsun istersen
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
