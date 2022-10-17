using Fluxor;
using LazyLoadBlazorModule.Actions;

namespace LazyLoadBlazorModule.Reducers
{
    internal class LoadItemsReducer : Reducer<LazyLoadBlazorModuleState, LoadItemsAction>
    {
        public override LazyLoadBlazorModuleState Reduce(LazyLoadBlazorModuleState state, LoadItemsAction action) =>
            new LazyLoadBlazorModuleState(false, Array.Empty<string>(), state.Items);
    }
}