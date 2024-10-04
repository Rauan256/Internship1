using Microsoft.AspNetCore.Mvc;
using Internship.Models;
using System.Diagnostics;

namespace Internship.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       
   

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetIndex()
        {
            return Ok("Welcomce");
        }

       
       

    }
}
