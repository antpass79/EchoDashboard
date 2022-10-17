using Fluxor;
using LazyLoadBlazorModule.Actions;

namespace LazyLoadBlazorModule.Reducers
{
    internal class LoadItemsSuccessReducer : Reducer<LazyLoadBlazorModuleState, LoadItemsSuccessAction>
    {
        public override LazyLoadBlazorModuleState Reduce(LazyLoadBlazorModuleState state, LoadItemsSuccessAction action) =>
            new LazyLoadBlazorModuleState(false, Array.Empty<string>(), action.Items);
     }
}