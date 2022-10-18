using Archive.Effects;
using Archive.Features;
using Archive.Reducers;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using MyLab.Platform.Frontend.Framework.Store;

namespace Archive.Store
{
    public class ArchiveStoreInitializer : StoreInitializer<ArchiveState>
    {
        public ArchiveStoreInitializer(IStore store, IServiceProvider serviceProvider)
            : base (store, serviceProvider) { }

        protected override IFeature<ArchiveState> BuildFeature(IServiceProvider? serviceProvider)
        {
            return new ArchiveFeature();
        }

        protected override IEnumerable<IReducer<ArchiveState>> BuildReducers(IServiceProvider? serviceProvider)
        {
            return new IReducer<ArchiveState>[]
            {
                new LoadWeatherForecastsReducer(),
                new LoadWeatherForecastsSuccessReducer(),
                new LoadWeatherForecastsFailedReducer()
            };
        }

        protected override IEnumerable<IEffect> BuildEffects(IServiceProvider? serviceProvider)
        {
            var httpClient = serviceProvider!.GetService<HttpClient>();

            return new IEffect[]
            {
                new LoadWeatherForecastsEffect(httpClient!)
            };
        }
    }
}
