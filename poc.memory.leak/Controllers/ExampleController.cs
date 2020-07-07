using Microsoft.AspNetCore.Mvc;
using poc.memory.leak.interfaces;
using poc.memory.leak.interfaces.Services;

namespace poc.memory.leak.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService _exampleService;

        public ExampleController(IExampleService exampleService)
        {
            _exampleService = exampleService;
        }


        [HttpGet]
        [Route("id/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_exampleService.GetItem(id));
        }
    }
}