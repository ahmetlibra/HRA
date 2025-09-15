using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record TenantDto(
     string? Name = null,
     string? Code = null,
     string? TimeZone = null,
     TenantType TenantType = TenantType.Internal,
     TenantConfigurationDto? TenantConfigurationDto= null);

    public record TenantConfigurationDto(
        string? ThemeColor = null,
        string? LogoUrl = null,
        string? Language = null,
        bool EnablePayroll = false,
        int MaxUsers = 0,
        string? Plan = null,
        string? DateFormat = null,
        bool EnforcePasswordPolicy = false,
        string? SupportContactUrl = null
        );

}
