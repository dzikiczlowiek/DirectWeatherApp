# DirectWeatherApp
Project summary.

### Front-end
Front-end application source is located in the `source\directe-weather-web` directory. 
This application uses Vue.js and Webpack framework. The URL to communicate with the WebApi application is located in the Search.vue file. To develop this part of the test application I used VisualStudioCode IDE with Vexter extension.

Requirements:
- installed node.js

The front-end application is launched using the `npm run dev` command executed in the application directory.

### WebApi
DirectWeatherApi is our WebApi application. This application uses the `https://openweathermap.org/api` service as a weather data source. 
OpenWeatherMap api configuration is included in the DirectWeatherApi web.config file.
I made a few changes beyond the requirements of the task:
- JSON response extended with status, message, and a timestamp fields. These fields improve communication between front-end and WebApi applications
- added API  versioning (current version `v1`) via URL, for example:

```
    http://localhost/DirectWeather.Api/api/v1/weather/poland/warsaw
```

            
### Tests projects
1. UnitTests: `DirectWeather.UnitTests`
2. IntegrationTests: `DirectWeather.IntegrationTests`, have the OpenWeatherMap api configuration in the api.config file
3. AcceptanceTests: `DirectWeather.AcceptanceTests` based on Selenium.WebDriver and LightBDD. In order to run these tests it is required to run a frontend and WebApi application (hosted on IIS)
