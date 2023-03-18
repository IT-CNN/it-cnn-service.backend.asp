using CNN.Core.Business.Models.UserModels;
using CNN.Core.Business.UseCases.UserUcs.Login;
using CNN.Core.Business.UseCases.UserUcs.WhoIAm;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CNN.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;

        private string _userName { get
            {
                return User.FindFirstValue(ClaimTypes.Name) ?? string.Empty;
            } }

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

        [HttpGet("WhoIAm"), Authorize]
        [ProducesResponseType(typeof(UserOutModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> WhoIAm()
        {
            var query = new WhoIAmQuery
            {
                UserName = _userName
            };
            try
            {
                var result = await _sender.Send(query);
                return Ok(result);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
    }
}
