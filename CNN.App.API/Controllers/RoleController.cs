using CNN.Core.Business.Models.ProductModel;
using CNN.Core.Business.UseCases.RoleUcs.GetRoleById;
using CNN.Core.Business.UseCases.RoleUcs.GetRolesQuery;
using CNN.Core.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CNN.App.API.Controllers;

[Route("api/[controller]"), Authorize]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly ISender _sender;

    public RoleController(ISender send)
    {
        _sender = send;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ICollection<ProductOutModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetRolesQuery();
        var result = await _sender.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:Guid}")]
    [ProducesResponseType(typeof(ProductOutModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOne([FromRoute] Guid id)
    {
        var query = new GetRoleByIdQuery(id);
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
