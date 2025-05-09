using Application.Commands.Users.Add;
using Application.Queries.Users.GetAll;
using Application.Queries.Users.GetById;
using Core.Utilities.Mediator.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {


        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand request)
        {
            var result = await mediator.Send(request);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUserQuery request)
        {
           
            var result = await mediator.Send(request);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdUserQuery request)
        {

            var result = await mediator.Send(request);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
