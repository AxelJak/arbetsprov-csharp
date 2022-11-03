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

            WeatherData weatherData = null;
            try {
                weatherData = await service.GetWeatherDataAsync(latitude, longitude, token);

            } catch(Exception e){
                Console.WriteLine(e);
            }
            var temp = weatherData.properties.timeseries[0].data.instant.details.air_temperature;
            var press = weatherData.properties.timeseries[0].data.instant.details.air_pressure_at_sea_level;
            var hum = weatherData.properties.timeseries[0].data.instant.details.relative_humidity;
            string code = weatherData.properties.timeseries[0].data.next_1_hours.summary.symbol_code;
            string airTemp = temp.ToString();
            string airPressure = press.ToString();
            string humidity = hum.ToString();

            Weather weather = new Weather{
                airTemp = airTemp,
                airPressure = airPressure,
                humidity = humidity,
                symbol_code = code};
            return Json(weather);        
        }
    }

    public class Weather{
        public string airTemp {get; set;}
        public string airPressure {get; set;}
        public string humidity {get; set;}
        public string symbol_code {get; set;}
    }
    public class Coordinates{
        public string latitude {get; set;}
        public string longitude {get; set;}
    }
}
