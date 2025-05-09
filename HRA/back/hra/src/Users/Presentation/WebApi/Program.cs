using Core.Utilities.Mediator.Abstract;
using Core.Utilities.Mediator.Concrete;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.HrsDbContext;
using WebApi.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Mediator
builder.Services.AddScoped<IMediator, CustomMediator>();

builder.Services.AddDbContext<HrsUserDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql")));
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



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
