using CNN.Core.Business.Models.CategoryModel;
using CNN.Core.Business.UseCases.CategoryUcs.AddCategory;
using CNN.Core.Business.UseCases.CategoryUcs.DeleteCategory;
using CNN.Core.Business.UseCases.CategoryUcs.GetCategories;
using CNN.Core.Business.UseCases.CategoryUcs.GetCategory;
using CNN.Core.Business.UseCases.CategoryUcs.PathCategory;
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
public class CategoryController : ControllerBase
{
    private readonly ISender _sender;

    public CategoryController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost, Authorize(Roles = AppRoles.ADMIN)]
    [ProducesResponseType(typeof(CategoryOutModel), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Dictionary<string, List<string>>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CategoryInModel model)
    {
        var cmd = new AddCategoryCommand(model);
        try
        {
            var result = await _sender.Send(cmd);
            return Created("", result);
        }catch(BadRequestException ex)
        {
            return BadRequest(ex.Errors);
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(ICollection<CategoryInModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetCategoriesQuery();
        var result = await _sender.Send(query);

        return Ok(result);
    }

    [HttpGet("{id:Guid}")]
    [ProducesResponseType(typeof(CategoryOutModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var query = new GetCategoryQuery(id);
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
    [ProducesResponseType(typeof(CategoryOutModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] JsonPatchDocument<Category> document, [FromRoute] Guid id)
    {
        var cmd = new PathCategoryCommand(document, id);
        try
        {
            var result = await _sender.Send(cmd);
            return Ok(result);
        }
        catch (NotFoundEntityException ex)
        {
            return NotFound(ex.Errors);
        }
    }

    [HttpDelete("{id:Guid}")]
    [ProducesResponseType(typeof(CategoryOutModel), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var query = new DeleteCategoryCommand(id);
        try
        {
            await _sender.Send(query);
            return NoContent();
        }
        catch (NotFoundEntityException ex)
        {
            return NotFound(ex.Errors);
        }
    }

}
