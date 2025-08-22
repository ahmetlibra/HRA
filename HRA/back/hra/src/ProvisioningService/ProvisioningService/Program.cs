using MassTransit;
using ProvisioningService;
using ProvisioningService.DBService.Abstract;
using ProvisioningService.DBService.Concrete;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddMassTransit(configurator =>
{
    // Consumer'ý DI container'a ve MassTransit'e kaydediyoruz.
    configurator.AddConsumer<TenantCreationRequestedConsumer>();




    configurator.UsingRabbitMq((context, cfg) =>
    {
        //ToDo :  Set for real
        cfg.Host("localhost", "/", h => {
            h.Username("guest");
            h.Password("guest");
        });

        // Consumer'ýn hangi kuyruðu dinleyeceðini belirliyoruz.
        cfg.ReceiveEndpoint("tenant-creation-queue", e =>
        {
            e.ConfigureConsumer<TenantCreationRequestedConsumer>(context);
        });
    });
});


builder.Services.AddScoped<IProvisionerFactory, ProvisionerFactory>();

builder.Services.AddScoped<IDbProvisioner, PostgresProvisioner>();
builder.Services.AddScoped<IDbProvisioner, MongoDbProvisioner>();

var host = builder.Build();
host.Run();
