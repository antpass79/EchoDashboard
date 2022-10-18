using Fluxor;
using LazyLoadBlazorModule.Effects;
using LazyLoadBlazorModule.Features;
using LazyLoadBlazorModule.Reducers;
using Microsoft.Extensions.DependencyInjection;
using MyLab.Platform.Frontend.Framework.Store;

namespace LazyLoadBlazorModule.Store
{
    public class LazyLoadBlazorModuleStoreInitializer : StoreInitializer<LazyLoadBlazorModuleState>
    {
        public LazyLoadBlazorModuleStoreInitializer(IStore store, IServiceProvider serviceProvider)
            : base (store, serviceProvider) { }

        protected override IFeature<LazyLoadBlazorModuleState> BuildFeature(IServiceProvider? serviceProvider)
        {
            return new LazyLoadBlazorModuleFeature();
        }

        protected override IEnumerable<IReducer<LazyLoadBlazorModuleState>> BuildReducers(IServiceProvider? serviceProvider)
        {
            return new IReducer<LazyLoadBlazorModuleState>[]
            {
                new LoadItemsReducer(),
                new LoadItemsSuccessReducer(),
                new LoadItemsFailedReducer()
            };
        }

        protected override IEnumerable<IEffect> BuildEffects(IServiceProvider? serviceProvider)
        {
            var httpClient = serviceProvider!.GetService<HttpClient>();

            return new IEffect[]
            {
                new LoadItemsEffect(httpClient!)
            };
        }
    }
}
