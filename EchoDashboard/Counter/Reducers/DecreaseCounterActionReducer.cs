using Counter.Actions;
using Fluxor;

namespace Counter.Reducers
{
    public class DecreaseCounterActionReducer : Reducer<CounterState, DecreaseCounterAction>
    {
        public override CounterState Reduce(CounterState state, DecreaseCounterAction action) =>
            new CounterState(state.IsLoading, state.ErrorMessages, state.Value - action.Value);
    }
}
