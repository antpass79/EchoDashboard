using Fluxor;

namespace Counter.Features
{
    internal class CounterFeature : Feature<CounterState>
    {
        public override string GetName() => nameof(CounterFeature);

        protected override CounterState GetInitialState()
        {
            return new CounterState();
        }
    }
}
