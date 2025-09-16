var builder = WebApplication.CreateBuilder(args);




builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));



var app = builder.Build();

app.Configuration.GetSection("ReverseProxy").Bind(new { });

app.MapReverseProxy();

app.MapGet("/", () => "Hello World!");

app.Run();
