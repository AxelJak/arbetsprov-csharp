
const weatherForm = document.getElementById('weather-form');
const weatherContainer = document.getElementById('weather-data-container');

weatherForm?.addEventListener('submit', (e) => {
  e.preventDefault();

  const longitude = document.getElementsById('longitud').value;
  const latitude = document.getElementsById('longitud').value;

  fetch('WeatherApi/GetWeatherForecast', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({longitude, latitude})
  })
  .then((response) => response.json())
  .then((data) => {
    alert(data)
  })
});
