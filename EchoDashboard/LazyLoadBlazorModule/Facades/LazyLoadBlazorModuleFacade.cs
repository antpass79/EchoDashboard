using LazyLoadBlazorModule.Actions;
using LazyLoadBlazorModule.Store;
using Platform.Frontend.Framework.Facades;

namespace LazyLoadBlazorModule.Facades
{
    public class LazyLoadBlazorModuleFacade : StateFacade<LazyLoadBlazorModuleState, LazyLoadBlazorModuleFacade, LazyLoadBlazorModuleStoreInitializer>
    {
        public Task RetrieveItemsAsync()
        {
            Dispatcher!.Dispatch(new LoadItemsAction());
            return Task.CompletedTask;
        }
    }
}
