using Arbetsprov.CSharp.Web.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using Arbetsprov.CSharp.Web.Models;

public class WeatherService : IWeatherService {

    static HttpClient client = new HttpClient();

    public async Task<WeatherData> GetWeatherDataAsync(string latitude, string longitude, CancellationToken cancellationToken){

        string apiUrl = $"https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={latitude}&lon={longitude}";

        var productName = new ProductInfoHeaderValue("WeatherWebsite","1.0");
        var commentName = new ProductInfoHeaderValue("(+https://github.com/xlent-norr/arbetsprov-csharp)");
        client.DefaultRequestHeaders.UserAgent.Add(productName);
        client.DefaultRequestHeaders.UserAgent.Add(commentName);

        WeatherData weatherData = null;

        HttpResponseMessage response = await client.GetAsync(apiUrl);
        var data = "";
        if (response.IsSuccessStatusCode){
            data = await response.Content.ReadAsStringAsync();
            weatherData = JsonConvert.DeserializeObject<WeatherData>(data);
        }
    return weatherData; 
    } 
}