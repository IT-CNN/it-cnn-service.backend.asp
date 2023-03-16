using CNN.Core.Business.UseCases.TestUcs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CNN.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ISender _sender;

        public TestController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var query = new TestQuery();
            var result = await _sender.Send(query);
            return Ok(result);
        }
    }
}
