using Archive.Models;

namespace Archive.Actions
{
    public class LoadWeatherForecastsSuccessAction
    {
        public LoadWeatherForecastsSuccessAction(IEnumerable<WeatherForecast> weatherForecasts) =>
            WeatherForecasts = weatherForecasts ?? Array.Empty<WeatherForecast>();

        public IEnumerable<WeatherForecast> WeatherForecasts { get; }
    }
}
