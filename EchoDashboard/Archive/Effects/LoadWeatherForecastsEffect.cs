using Archive.Actions;
using Archive.Models;
using Fluxor;
using System.Net.Http.Json;

namespace Archive.Effects
{
    public class LoadWeatherForecastsEffect : Effect<LoadWeatherForecastsAction>
    {
        private readonly HttpClient _httpClient;
        private readonly IDispatcher _dispatcher;

        public LoadWeatherForecastsEffect(HttpClient httpClient, IDispatcher dispatcher)
        {
            _httpClient = httpClient;
            _dispatcher = dispatcher;
        }

        public override async Task HandleAsync(LoadWeatherForecastsAction action, IDispatcher dispatcher)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
                _dispatcher.Dispatch(new LoadWeatherForecastsSuccessAction(response!));
            }
            catch (Exception exception)
            {
                _dispatcher.Dispatch(new LoadWeatherForecastsFailedAction(exception.Message));
            }
        }
    }
}
