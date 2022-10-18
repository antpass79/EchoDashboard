using LazyLoadBlazorModule.Facades;
using LazyLoadBlazorModule.Features;
using LazyLoadBlazorModule.Models;
using LazyLoadBlazorModule.Store;
using MyLab.Platform.Frontend.Framework;

namespace LazyLoadBlazorModule
{
    public class EntryPointComponentDataModel : MyLabComponentBase<LazyLoadBlazorModuleState, LazyLoadBlazorModuleFacade, LazyLoadBlazorModuleStoreInitializer>
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
