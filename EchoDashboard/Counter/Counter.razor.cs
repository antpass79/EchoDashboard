using Counter.Facades;
using Counter.Features;
using Counter.Store;
using MyLab.Platform.Frontend.Framework;

namespace Counter
{
    public class CounterDataModel : MyLabComponentBase<CounterState, CounterFacade, CounterStoreInitializer>
    {
        public CounterDataModel()
            : base (nameof(CounterFeature)) { }

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
