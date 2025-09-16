using Core.Data.Abstract;
using Core.Entities.Concrete.Wrappers;
using Core.Enums;
using Core.Utilities.Mediator.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Tenant.Add
{
    public class AddTenantCommandHandler(
         IPgRepository<Domain.Entities.Tenant> tenantRepository,
         IPgRepository<TenantConfiguration> tenantConfigurationRepository

        ) : IRequestHandler<AddTenantCommand, ServiceResponse<AddTenantResponse>>
    {
        public async Task<ServiceResponse<AddTenantResponse>> Handle(AddTenantCommand request)
        {
            Domain.Entities.Tenant tenant = new Domain.Entities.Tenant()
            {
                Name = request.TenantDto.Name,
                Code = request.TenantDto.Code,
                ConnectionStringKey = null,
                CreatedUserId = Guid.Empty,
                TimeZone = request.TenantDto.TimeZone,
                Status = TenantStatus.Pending,
                StorageType = request.TenantDto.TenantType == TenantType.Internal ? TenantStorageType.Shared : TenantStorageType.Dedicated,
                Type = request.TenantDto.TenantType
                


            };
            await tenantRepository.Add(tenant);
            TenantConfiguration tenantConfiguration = new TenantConfiguration()
            {
                TenantId = tenant.Id,
                CreatedUserId = Guid.Empty,
                DateFormat = request.TenantDto.TenantConfigurationDto.DateFormat,
                EnablePayroll = request.TenantDto.TenantConfigurationDto.EnablePayroll,
                EnforcePasswordPolicy = request.TenantDto.TenantConfigurationDto.EnforcePasswordPolicy,
                Language = request.TenantDto.TenantConfigurationDto.Language,
                LogoUrl = request.TenantDto.TenantConfigurationDto.LogoUrl,
                MaxUsers = request.TenantDto.TenantConfigurationDto.MaxUsers,
                Plan = request.TenantDto.TenantConfigurationDto.Plan,
                SupportContactUrl =request.TenantDto.TenantConfigurationDto.SupportContactUrl,
                ThemeColor = request.TenantDto.TenantConfigurationDto.ThemeColor,
                EntityStatus = EntityStatus.Pending,

            };


            await tenantConfigurationRepository.Add(tenantConfiguration);


            return await Task.FromResult(new ServiceResponse<AddTenantResponse>
            {
                Data = new AddTenantResponse()
                {
                    IsSuccess = true,
                },
                Success = true,
                Message = "Tenant added successfully"
            });
        }
    }
}


