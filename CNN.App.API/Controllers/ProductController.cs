using CNN.Core.Business.Models.ProductModel;
using CNN.Core.Business.UseCases.ProductUcs.AddProduct;
using CNN.Core.Domain;
using CNN.Core.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CNN.App.API.Controllers
{
    [Route("api/[controller]")]
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
    }
}
