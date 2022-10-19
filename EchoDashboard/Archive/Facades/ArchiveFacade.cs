using Archive.Actions;
using Archive.Store;
using Fluxor;
using Platform.Frontend.Framework.Facades;

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
