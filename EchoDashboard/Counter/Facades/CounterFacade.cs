using Counter.Actions;
using Counter.Store;
using Fluxor;
using Platform.Frontend.Framework.Facades;

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
