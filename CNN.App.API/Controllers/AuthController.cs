using CNN.Core.Business.Models.UserModels;
using CNN.Core.Business.UseCases.UserUcs.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CNN.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(UserAuthOutModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var query = new LoginQuery(model);
            try
            {
                var result = await _sender.Send(query);
                return Ok(result);
            }catch(UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
    }
}
