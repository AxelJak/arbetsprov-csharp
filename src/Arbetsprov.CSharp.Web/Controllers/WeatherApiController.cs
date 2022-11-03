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

            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ",";

            double latitude = Convert.ToDouble(coords.latitud, provider);
            double longitude = Convert.ToDouble(coords.longitud, provider);

            WeatherService service = new WeatherService();

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
        public string latitud {get; set;}
        public string longitud {get; set;}
    }
}
