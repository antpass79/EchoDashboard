using Archive.Models;
using Platform.Frontend.Framework;

namespace Archive
{
    public class ArchiveState : BaseState
    {
        public ArchiveState(bool isLoading, IEnumerable<string> errorMessages, IEnumerable<WeatherForecast> weatherForecasts)
            : base(isLoading, errorMessages) =>
            WeatherForecasts = weatherForecasts;

        public IEnumerable<WeatherForecast> WeatherForecasts { get; init;  }
    }
}
