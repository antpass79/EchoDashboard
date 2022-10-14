using Archive.Actions;
using Archive.Models;
using Fluxor;

namespace Archive.Reducers
{
    internal class LoadWeatherForecastsFailedReducer : Reducer<ArchiveState, LoadWeatherForecastsFailedAction>
    {
        public override ArchiveState Reduce(ArchiveState state, LoadWeatherForecastsFailedAction action) =>
            new ArchiveState(false, new[] { action.ErrorMessage }, Array.Empty<WeatherForecast>());
    }
}