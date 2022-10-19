using Archive.Actions;
using Archive.Facades;
using Archive.Features;
using Archive.Store;
using Platform.Frontend.Framework;

namespace Archive
{
    public class ArchiveDataModel : BasePageComponent<ArchiveState, ArchiveFacade, ArchiveStoreInitializer>
    {
        public ArchiveDataModel()
            : base (nameof(ArchiveState)) { }

        protected override async Task OnInitializeComponentAsync()
        {
            await RetrieveWeatherForecastsAsync();
        }

        protected async Task RetrieveWeatherForecastsAsync()
        {
            await Facade!.RetrieveWeatherForecastsAsync();
        }
    }
}
