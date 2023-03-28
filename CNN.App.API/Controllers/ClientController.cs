using CNN.Core.Business.Models.ClientModel;
using CNN.Core.Business.UseCases.ClientUcs.AddClient;
using CNN.Core.Business.UseCases.ClientUcs.DeleteClient;
using CNN.Core.Business.UseCases.ClientUcs.GetClient;
using CNN.Core.Business.UseCases.ClientUcs.GetClients;
using CNN.Core.Business.UseCases.ClientUcs.PathClient;
using CNN.Core.Domain;
using CNN.Core.Domain.Entities;
using CNN.Core.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CNN.App.API.Controllers;

[Route("api/[controller]")]
[ApiController, Authorize]
public class ClientController : ControllerBase
{
    private readonly ISender _sender;

    public ClientController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost, Authorize(Roles = AppRoles.ADMIN)]
    [ProducesResponseType(typeof(ClientOutModel), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Dictionary<string, List<string>>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create([FromBody] ClientInModel model)
    {
        var cmd = new AddClientCommand(model);
        try
        {
            var result = await _sender.Send(cmd);
            return CreatedAtAction(nameof(Get), result);
        }catch(BadRequestException ex)
        {
            return BadRequest(ex.Errors);
        }catch(NotFoundEntityException ex)
        {
            return NotFound(ex.Errors);
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(ICollection<ClientOutModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var query = new GetClientsQuery();
        var result = await _sender.Send(query);

        return Ok(result);
    }

    [HttpGet("{id:Guid}")]
    [ProducesResponseType(typeof(ClientOutModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var query = new GetClientQuery(id);
        try
        {
            var result = await _sender.Send(query);
            return Ok(result);
        }catch(NotFoundEntityException ex)
        {
            return NotFound(ex.Errors);
        }
    }

    [HttpPatch("{id:Guid}")]
    [ProducesResponseType(typeof(ClientOutModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Path([FromBody] JsonPatchDocument<Client> document, [FromRoute] Guid id)
    {
        var cmd = new PathClientCommand(document, id);

        try
        {
            var result = await _sender.Send(cmd);
            return Ok(result);
        }
        catch(NotFoundEntityException ex)
        {
            return NotFound(ex.Errors);
        }
    }

    [HttpDelete("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var cmd = new DeleteClientCommand(id);
        try
        {
            await _sender.Send(cmd);
            return NoContent();
        }
        catch(NotFoundEntityException ex)
        {
            return NotFound(ex.Errors);
        }
    }


}
