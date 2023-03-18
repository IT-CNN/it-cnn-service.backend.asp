using CNN.Core.Business.Models.UserModels;
using CNN.Core.Business.UseCases.UserUcs.AddOneUser;
using CNN.Core.Business.UseCases.UserUcs.AddUserAdmin;
using CNN.Core.Business.UseCases.UserUcs.AddUserByCsvFile;
using CNN.Core.Business.UseCases.UserUcs.GetUserById;
using CNN.Core.Business.UseCases.UserUcs.GetUsers;
using CNN.Core.Domain;
using CNN.Core.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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


        [HttpPost("{role}"), Authorize(Roles = AppRoles.ADMIN)]
        [ProducesResponseType(typeof(UserOutModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Dictionary<string, List<string>>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateOtherOne([FromForm] UserInModel user, [FromRoute] string role)
        {
            var cmd = new AddOneUserCommand
            {
                Role = role,
                User = user
            };

            try
            {
                var result = await _sender.Send(cmd);
                return Created("", result);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [HttpPost("ByCsv"), Authorize(Roles = AppRoles.ADMIN)]
        [ProducesResponseType(typeof(UserCsvModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public  async Task<IActionResult> CreateOtherByCsv(
            [FromForm] AddUserByCsvFileCommand cmd
            )
        {

            try
            {
                var result = await _sender.Send(cmd);
                return Ok(result);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }


        [HttpGet, Authorize(Roles = AppRoles.ADMIN)]
        [ProducesResponseType(typeof(UserOutModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetUsersQuery();
            var result = await _sender.Send(query);
            return Ok(result);
        }

        [HttpGet("{id:Guid}"), Authorize(Roles = AppRoles.ADMIN)]
        [ProducesResponseType(typeof(UserOutModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            var query = new GetUserByIdQuery
            {
                Id = id
            };
            try
            {
                var result = await _sender.Send(query);
                return Ok(result);
            }catch(NotFoundEntityException ex)
            {
                return NotFound(ex.Errors);
            }
        }
    }
}
