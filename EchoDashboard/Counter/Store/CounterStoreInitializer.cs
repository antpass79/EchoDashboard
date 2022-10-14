using Counter.Features;
using Counter.Reducers;
using EchoDashboard.Shared.Facades;
using EchoDashboard.Shared.Store;
using Fluxor;

namespace Counter.Store
{
    public class CounterStoreInitializer : StoreInitializer<CounterState>
    {
        public CounterStoreInitializer(IStore store, IServiceProvider serviceProvider)
            : base (store, serviceProvider) { }

        protected override IFeature<CounterState> BuildFeature(IServiceProvider? serviceProvider)
        {
            return new CounterFeature();
        }

        protected override IEnumerable<IReducer<CounterState>> BuildReducers(IServiceProvider? serviceProvider)
        {
            return new IReducer<CounterState>[]
            {
                new IncreaseCounterActionReducer(),
                new DecreaseCounterActionReducer()
            };
        }
    }
}
