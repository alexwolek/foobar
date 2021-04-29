using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Foobar.Api.Controllers
{
    [ApiController]
    [Route("foobars")]
    public class FoobarsController : ControllerBase
    {
        private readonly ILogger<FoobarsController> _logger;

        public FoobarsController(ILogger<FoobarsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var foobars = new [] 
            {
                new {foo = "bar"},
                new {foo = "baz"},
            };

            return Ok(foobars);
        }
    }
}
