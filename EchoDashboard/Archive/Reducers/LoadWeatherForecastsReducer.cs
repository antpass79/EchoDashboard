using Archive.Actions;
using Archive.Models;
using Fluxor;

namespace Archive.Reducers
{
    internal class LoadWeatherForecastsReducer : Reducer<ArchiveState, LoadWeatherForecastsAction>
    {
        public override ArchiveState Reduce(ArchiveState state, LoadWeatherForecastsAction _) =>
            new ArchiveState(true, Array.Empty<string>(), Array.Empty<WeatherForecast>());
    }
}