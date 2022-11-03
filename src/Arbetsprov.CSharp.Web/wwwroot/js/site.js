
const weatherForm = document.getElementById('weather-form');
const weatherContainer = document.getElementById('weather-data-container');
const airTemp = document.getElementById('air-temp');
const airPressure = document.getElementById('air-pressure');
const humidity = document.getElementById('humidity');
const symbol = document.getElementById('symbol');


weatherForm?.addEventListener('submit', (e) => {
  e.preventDefault();

  const longitude = document.getElementById('longitude').value;
  const latitude = document.getElementById('latitude').value;

  var data = JSON.stringify({latitude, longitude});

  fetch('/WeatherApi/GetWeatherForecast', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: data
  })
  .then((response) => response.json())
  .then((data) => {
    airTemp.innerHTML = data.airTemp + " ºC";
    airPressure.innerHTML = data.airPressure+ " hPa";
    humidity.innerHTML = data.humidity + " %";
    symbol.innerHTML = data.symbol_code;
  });

});

// function setWeatherCondition(symbol_code){
//   console.log(symbol_code);
//   switch(symbol_code){
//     case "cloudy":
//       imgSrc = "../../wwwroot/cloud.png";
//       break;
//     case "clearsky":
//       imgSrc = "../../wwwroot/sunglasses.png";
//       break;
//     case "lightrain":
//     case "heavyrain":
//       imgSrc = "../../wwwroot/rainy.png";
//       break;
//     case "partlycloudy":
//     case "fair":
//       imgSrc = "../../wwwroot/cloudy-day.png";
//       break;
//     default:
//       imgSrc = "../../wwwroot/cloudy-day.png";
//   }
// }
