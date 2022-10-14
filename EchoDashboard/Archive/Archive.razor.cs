using Archive.Effects;
using Archive.Facades;
using Archive.Features;
using Archive.Models;
using Archive.Reducers;
using Archive.Store;
using EchoDashboard.Shared;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;

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
