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


builder.Services.AddDbContext<HrsDbContext>(options =>
    options.UseNpgsql("ConnectionStrings"));
builder.Services.AddProjectServices();



var app = builder.Build();



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
