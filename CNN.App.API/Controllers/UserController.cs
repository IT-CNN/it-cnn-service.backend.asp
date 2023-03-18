using CNN.Core.Business.Models.UserModels;
using CNN.Core.Business.UseCases.UserUcs.AddUserAdmin;
using CNN.Core.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CNN.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("Admin")]
        [ProducesResponseType(typeof(UserOutModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Dictionary<string, List<string>>),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAdminUser([FromForm] UserInModel user)
        {
            var cmd = new AddUserAdminCommand
            {
                User= user
            };

            try
            {
                var result = await _sender.Send(cmd);
                return Created("", result);
            }catch (BadRequestException ex)
            {
                return BadRequest(ex.Errors);
            }
        }
    }
}
