using Microsoft.AspNetCore.Mvc;

namespace ProyectoGenericoNet.Api.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("messi")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "messi")]
        public string Get()
        {
            var variablePrueba = _configuration["VARIABLE_PRUEBA"] ?? "(no configurada)";
            var message = $"Hola Mundo desde el controlador WeatherForecastController. VARIABLE_PRUEBA = {variablePrueba}";
            return message;
        }
    }
}
