using Counter.Facades;
using Counter.Features;
using Counter.Store;
using Platform.Frontend.Framework;

namespace Counter
{
    public class CounterDataModel : BasePageComponent<CounterState, CounterFacade, CounterStoreInitializer>
    {
        public CounterDataModel()
            : base (nameof(CounterState)) { }

        protected void IncrementCount()
        {
            Facade!.IncreaseCounter();
        }

        protected void DecrementCount()
        {
            Facade!.DecreaseCounter();
        }
    }
}
