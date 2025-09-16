using Core.Database.Abstraction;
using Core.Database.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence.Data.HrsDbContext;
using WebApi.DependencyResolvers;
using Core.Extensions.DbHostExtension;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Tenant API",
        Version = "v1"
    });
});




builder.Services.AddDbContext<HrsTenantDbContext>(options =>
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

//Generet db if not exist
await app.UseEfCoreDbInitializerAsync<HrsTenantDbContext>();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "Tenant API Dokümantasyonu";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
