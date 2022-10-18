using Fluxor;

namespace Counter.Features
{
    internal class CounterFeature : Feature<CounterState>
    {
        public override string GetName() => nameof(CounterState);

        protected override CounterState GetInitialState()
        {
            return new CounterState();
        }
    }
}
