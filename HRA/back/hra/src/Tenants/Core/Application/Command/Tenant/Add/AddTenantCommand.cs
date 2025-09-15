using Application.Dtos;
using Core.Entities.Concrete.Wrappers;
using Core.Utilities.Mediator.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Tenant.Add
{
    public record AddTenantCommand(TenantDto TenantDto):IRequest<ServiceResponse<AddTenantResponse>>;
}
