using Archive.Models;

namespace Archive.Actions
{
    public class LoadWeatherForecastsSuccessAction
    {
        public LoadWeatherForecastsSuccessAction(IEnumerable<WeatherForecast> weatherForecasts) =>
            WeatherForecasts = weatherForecasts;

        public IEnumerable<WeatherForecast> WeatherForecasts { get; }
    }
}
