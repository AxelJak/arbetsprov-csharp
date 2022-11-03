
const weatherForm = document.getElementById('weather-form');
const weatherContainer = document.getElementById('weather-data-container');
const airTemp = document.getElementById('air-temp');
const airPressure = document.getElementById('air-pressure');

weatherForm?.addEventListener('submit', (e) => {
  e.preventDefault();

  const longitude = document.getElementById('longitude').value;
  const latitude = document.getElementById('latitude').value;

  var data = JSON.stringify({latitude, longitude});
  console.log(data);

  fetch('/WeatherApi/GetWeatherForecast', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: data
  })
  .then((response) => response.json())
  .then((data) => {
    airTemp.innerHTML = data;
  });

});
