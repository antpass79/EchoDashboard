using LazyLoadBlazorModule.Actions;
using LazyLoadBlazorModule.Models;
using Fluxor;
using System.Net.Http.Json;

namespace LazyLoadBlazorModule.Effects
{
    public class LoadItemsEffect : Effect<LoadItemsAction>
    {
        private readonly HttpClient _httpClient;

        public LoadItemsEffect(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public override async Task HandleAsync(LoadItemsAction action, IDispatcher dispatcher)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<Item[]>("WeatherForecast");
                dispatcher.Dispatch(new LoadItemsSuccessAction(response!));
            }
            catch (Exception exception)
            {
                dispatcher.Dispatch(new LoadItemsFailedAction(exception.Message));
            }
        }
    }
}
