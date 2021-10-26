using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Foobar.Api.Models;
using Foobar.Api.Repositories;

namespace Foobar.Api.Controllers
{
    [ApiController]
    [Route("foobars")]
    public class FoobarsController : ControllerBase
    {
        private readonly IFooRepository _repository;
        private readonly ILogger<FoobarsController> _logger;

        /// <summary>
        /// default constructor
        /// </summary>
        public FoobarsController(IFooRepository repository, ILogger<FoobarsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("in get foobars endpoint");

            var foobars = _repository.GetFoobars();

            return Ok(foobars);
        }

        [HttpPost]
        public IActionResult AddFoobar([FromBody] Foo foo)
        {
            _logger.LogInformation("in add foobar endpoint");

            _repository.AddFoo(foo);

            return NoContent();
        }
    }
    
}
