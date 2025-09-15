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
         IPgRepository<Domain.Entities.Tenant> teanantRepository,
         IPgRepository<TenantConfiguration> tenantConfigurationRepository

        ) : IRequestHandler<AddTenantCommand, ServiceResponse<AddTenantResponse>>
    {
        public Task<ServiceResponse<AddTenantResponse>> Handle(AddTenantCommand request)
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
            return  Task.FromResult(new ServiceResponse<AddTenantResponse>
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
