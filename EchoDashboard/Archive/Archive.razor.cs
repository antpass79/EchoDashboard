using Archive.Actions;
using Archive.Facades;
using Archive.Features;
using Archive.Store;
using MyLab.Platform.Frontend.Framework;

namespace Archive
{
    public class ArchiveDataModel : MyLabComponentBase<ArchiveState, ArchiveFacade, ArchiveStoreInitializer>
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
