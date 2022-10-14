using Archive.Actions;
using Archive.Effects;
using Archive.Features;
using Archive.Reducers;
using Archive.Store;
using EchoDashboard.Shared.Facades;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;

namespace Archive.Facades
{
    public class ArchiveFacade : StateFacade<ArchiveState, ArchiveFacade, ArchiveStoreInitializer>
    {
        public Task RetrieveWeatherForecastsAsync()
        {
            Dispatcher!.Dispatch(new LoadWeatherForecastsAction());
            return Task.CompletedTask;
        }
    }
}
