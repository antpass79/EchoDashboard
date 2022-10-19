using LazyLoadBlazorModule.Facades;
using LazyLoadBlazorModule.Store;
using Platform.Frontend.Framework;

namespace LazyLoadBlazorModule
{
    public class EntryPointComponentDataModel : BasePageComponent<LazyLoadBlazorModuleState, LazyLoadBlazorModuleFacade, LazyLoadBlazorModuleStoreInitializer>
    {
        public EntryPointComponentDataModel()
            : base (nameof(LazyLoadBlazorModuleState)) { }

        protected override async Task OnInitializeComponentAsync()
        {
            await RetrieveItemsAsync();
        }

        protected async Task RetrieveItemsAsync()
        {
            await Facade!.RetrieveItemsAsync();
        }
    }
}
