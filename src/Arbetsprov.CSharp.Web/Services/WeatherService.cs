
using System.Threading.Tasks;
using Arbetsprov.CSharp.Web.Models;

namespace Arbetsprov.CSharp.Web.Services
{
    public class WeatherService
    {
        public Task<WeatherData> GetWeatherDataAsync(double latitude, double longitude)
        {
            return Task.FromResult(new WeatherData());
        }
    }
}