using Application.Queries.Users.GetAll;
using Core.Utilities.Mediator.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUserQuery request, CancellationToken cancellationToken)
        {
           
            var result = await mediator.Send(request);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
