using Archive.Actions;
using Archive.Models;
using Fluxor;
using System.Net.Http.Json;

namespace Archive.Effects
{
    public class LoadWeatherForecastsEffect : Effect<LoadWeatherForecastsAction>
    {
        private readonly HttpClient _httpClient;

        public LoadWeatherForecastsEffect(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public override async Task HandleAsync(LoadWeatherForecastsAction action, IDispatcher dispatcher)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
                dispatcher.Dispatch(new LoadWeatherForecastsSuccessAction(response!));
            }
            catch (Exception exception)
            {
                dispatcher.Dispatch(new LoadWeatherForecastsFailedAction(exception.Message));
            }
        }
    }
}
