using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using Arbetsprov.CSharp.Web.Models;

namespace Arbetsprov.CSharp.Web.Controllers
{
    //[Route("api/weather")]
    public class WeatherApiController : Controller
    {
        public async Task<JsonResult> GetWeatherForecast([FromBody] Coordinates coords){
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            string latitude = coords.latitude;
            string longitude = coords.longitude;
           

            WeatherService service = new WeatherService();
            System.Console.WriteLine("Latitude api {0}",coords.latitude);

            WeatherData weatherData = null;
            try {
                weatherData = await service.GetWeatherDataAsync(latitude, longitude, token);

            } catch(Exception e){
                Console.WriteLine(e);
            }
            var temp = weatherData.properties.timeseries[0].data.instant.details.air_temperature;
            string airTemp = temp.ToString();
            
            return Json(airTemp);        
        }
    }

    public class Coordinates{
        public string latitude {get; set;}
        public string longitude {get; set;}
    }
}
