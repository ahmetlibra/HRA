using Application.Command.Tenant.Add;
using Core.Utilities.Mediator.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController(IMediator mediator) : ControllerBase
    {
        [HttpPost("AddTenant")]
        public async Task<IActionResult> AddTenant([FromBody] AddTenantCommand request)
        {
            var result = await mediator.Send(request);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

    }
}
