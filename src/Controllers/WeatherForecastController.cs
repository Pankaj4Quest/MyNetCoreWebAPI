using Microsoft.AspNetCore.Mvc;

namespace MyNetCoreWebAPI.Controllers
{
    public class MySample
    {
        public string name;
        public int Age;
    }


    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    //[Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            MySample obj1 = new MySample() { name = "Pankaj", Age = 35 };
            MySample obj2;
            obj2 = obj1;

            MySample obj3 = new MySample() { name = "Pankaj", Age = 35 };


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)] + "   " + (obj1.Equals(obj2)).ToString() + "   " + (obj1.Equals(obj3)).ToString()
            })
            .ToArray();
        }
    }
}
