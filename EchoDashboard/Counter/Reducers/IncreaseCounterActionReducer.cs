using Counter.Actions;
using Fluxor;

namespace Counter.Reducers
{
    public class IncreaseCounterActionReducer : Reducer<CounterState, IncreaseCounterAction>
    {
        public override CounterState Reduce(CounterState state, IncreaseCounterAction action) =>
            new CounterState(state.IsLoading, state.ErrorMessages, state.Value + action.Value);
    }
}
