using Archive.Facades;
using Archive.Features;
using Archive.Store;
using MyLab.Platform.Frontend.Framework;

namespace Archive
{
    public class ArchiveDataModel : MyLabComponentBase<ArchiveState, ArchiveFacade, ArchiveStoreInitializer>
    {
        public ArchiveDataModel()
            : base (nameof(ArchiveFeature)) { }

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
