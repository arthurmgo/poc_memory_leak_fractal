using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using poc.memory.leak.interfaces.Services;

namespace poc_memory_leak_fractal_2._2.Controllers
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
