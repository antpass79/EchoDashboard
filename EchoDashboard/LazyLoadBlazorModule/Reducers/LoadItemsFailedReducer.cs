using Fluxor;
using LazyLoadBlazorModule.Actions;
using LazyLoadBlazorModule.Models;

namespace LazyLoadBlazorModule.Reducers
{
    internal class LoadItemsFailedReducer : Reducer<LazyLoadBlazorModuleState, LoadItemsFailedAction>
    {
        public override LazyLoadBlazorModuleState Reduce(LazyLoadBlazorModuleState state, LoadItemsFailedAction action) =>
            new LazyLoadBlazorModuleState(false, new[] { action.ErrorMessage }, Array.Empty<Item>());
    }
}