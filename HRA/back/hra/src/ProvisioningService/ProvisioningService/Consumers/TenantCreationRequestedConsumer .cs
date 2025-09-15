using Core.Events.Tenant;
using MassTransit;
using ProvisioningService.DBService.Abstract;


public class TenantCreationRequestedConsumer : IConsumer<TenantCreationRequested>
{
    private readonly IProvisionerFactory _provisionerFactory; // Artık doğrudan provisioner'ı değil, fabrikayı enjekte ediyoruz.
    private readonly ILogger<TenantCreationRequestedConsumer> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public TenantCreationRequestedConsumer(IProvisionerFactory provisionerFactory)
    {
        _provisionerFactory = provisionerFactory;
        
    }

    public async Task Consume(ConsumeContext<TenantCreationRequested> context)
    {
        var message = context.Message;
        _logger.LogInformation("Provisioning started for Tenant ID: {TenantId} with DB Type: {DbType}", message.TenantId, message.DatabaseType);

        try
        {
            // 1. Fabrikadan doğru provisioner'ı al
            IDbProvisioner provisioner = _provisionerFactory.GetProvisioner(message.DatabaseType);

            // 2. Provision işlemini başlat
            await provisioner.ProvisionTenantDatabaseAsync(message.TenantCode);

            await _publishEndpoint.Publish(new TenantProvisioningSucceeded(message.TenantId));
            _logger.LogInformation("Provisioning SUCCEEDED for Tenant ID: {TenantId}", message.TenantId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Provisioning FAILED for Tenant ID: {TenantId}", message.TenantId);
            await _publishEndpoint.Publish(new TenantProvisioningFailed(message.TenantId, ex.Message));
        }
    }
}