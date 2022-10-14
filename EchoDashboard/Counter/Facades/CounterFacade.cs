using Counter.Actions;
using Counter.Features;
using Counter.Reducers;
using Counter.Store;
using EchoDashboard.Shared.Facades;
using Fluxor;

namespace Counter.Facades
{
    public class CounterFacade : StateFacade<CounterState, CounterFacade, CounterStoreInitializer>
    {
        public void IncreaseCounter()
        {
            Dispatcher!.Dispatch(new IncreaseCounterAction(1));
        }
        public void DecreaseCounter()
        {
            Dispatcher!.Dispatch(new DecreaseCounterAction(1));
        }
    }
}
