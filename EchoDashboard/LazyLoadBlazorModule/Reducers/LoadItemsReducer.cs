using Fluxor;
using LazyLoadBlazorModule.Actions;
using LazyLoadBlazorModule.Models;

namespace LazyLoadBlazorModule.Reducers
{
    internal class LoadItemsReducer : Reducer<LazyLoadBlazorModuleState, LoadItemsAction>
    {
        public override LazyLoadBlazorModuleState Reduce(LazyLoadBlazorModuleState state, LoadItemsAction _) =>
            new LazyLoadBlazorModuleState(true, Array.Empty<string>(), Array.Empty<Item>());
    }
}