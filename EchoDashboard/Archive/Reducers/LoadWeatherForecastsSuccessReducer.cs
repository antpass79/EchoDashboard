using Archive.Actions;
using Fluxor;

namespace Archive.Reducers
{
    internal class LoadWeatherForecastsSuccessReducer : Reducer<ArchiveState, LoadWeatherForecastsSuccessAction>
    {
        public override ArchiveState Reduce(ArchiveState state, LoadWeatherForecastsSuccessAction action) =>
            new ArchiveState(false, Array.Empty<string>(), action.WeatherForecasts);
     }
}