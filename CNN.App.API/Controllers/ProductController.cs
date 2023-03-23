using CNN.Core.Business.Models.ProductModel;
using CNN.Core.Business.UseCases.PathProduct;
using CNN.Core.Business.UseCases.ProductUcs.AddProduct;
using CNN.Core.Business.UseCases.ProductUcs.DeleteProductById;
using CNN.Core.Business.UseCases.ProductUcs.GetAllProducts;
using CNN.Core.Business.UseCases.ProductUcs.GetProductById;
using CNN.Core.Domain;
using CNN.Core.Domain.Entities;
using CNN.Core.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CNN.App.API.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost, Authorize(Roles = AppRoles.ADMIN)]
        [ProducesResponseType(typeof(ProductOutModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] ProductInModel product)
        {
            var cmd = new AddProductCommand(product);
            try
            {
                var p = await _sender.Send(cmd);
                return Created("", p);
            }catch(NotFoundEntityException ex)
            {
                return NotFound(ex.Errors);
            }catch(BadRequestException ex)
            {
                return BadRequest(ex.Errors);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<ProductOutModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sender.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(ProductOutModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            try
            {
                var result = await _sender.Send(new GetProductByIdQuery
                {
                    Id = id
                });
                return Ok(result);
            }catch(NotFoundEntityException ex)
            {
                return NotFound(ex.Errors);
            }
        }

        [HttpPatch("{id:Guid}")]
        [ProducesResponseType(typeof(ProductOutModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Path([FromRoute] Guid id, [FromBody] JsonPatchDocument<Product> jsonPatchDocument)
        {
            var cmd = new PathProductCommand(id, jsonPatchDocument);
            try
            {
                var result = await _sender.Send(cmd);
                return Ok(result);
            }catch(NotFoundEntityException ex)
            {
                return NotFound(ex.Errors);
            }
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(typeof(ProductOutModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var cmd = new DeleteProductByIdCommand(id);
            try
            {
                var result = await _sender.Send(cmd);
                return NoContent();
            }catch(NotFoundEntityException ex)
            {
                return NotFound(ex.Errors);
            }
        }
    }
}
