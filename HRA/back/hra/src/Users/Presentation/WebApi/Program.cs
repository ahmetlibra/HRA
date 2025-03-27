var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();




var app = builder.Build();

app.MapGet("/", () => "Hello, World!");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
