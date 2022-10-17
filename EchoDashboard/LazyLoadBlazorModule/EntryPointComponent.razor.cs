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
            : base (nameof(LazyLoadBlazorModuleFeature)) { }

        protected override async Task OnInitializeComponentAsync()
        {
            await RetrieveItemsAsync();
        }

        protected IEnumerable<Item> Items
        {
            get
            {
                Console.WriteLine(State?.Items?.Count());
                var items = State?.Items;
                return items;
            }
        }

        protected async Task RetrieveItemsAsync()
        {
            await Facade!.RetrieveItemsAsync();
        }
    }
}
