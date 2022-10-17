using LazyLoadBlazorModule.Actions;
using LazyLoadBlazorModule.Models;
using Fluxor;
using System.Net.Http.Json;

namespace LazyLoadBlazorModule.Effects
{
    public class LoadItemsEffect : Effect<LoadItemsAction>
    {
        private readonly HttpClient _httpClient;
        private readonly IDispatcher _dispatcher;

        public LoadItemsEffect(HttpClient httpClient, IDispatcher dispatcher)
        {
            _httpClient = httpClient;
            _dispatcher = dispatcher;
        }

        public override async Task HandleAsync(LoadItemsAction action, IDispatcher dispatcher)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<Item[]>("WeatherForecast");
                _dispatcher.Dispatch(new LoadItemsSuccessAction(response!));
            }
            catch (Exception exception)
            {
                _dispatcher.Dispatch(new LoadItemsFailedAction(exception.Message));
            }
        }
    }
}
