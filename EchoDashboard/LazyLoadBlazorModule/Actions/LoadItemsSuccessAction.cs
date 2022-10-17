using LazyLoadBlazorModule.Models;

namespace LazyLoadBlazorModule.Actions
{
    public class LoadItemsSuccessAction
    {
        public LoadItemsSuccessAction(IEnumerable<Item> items) =>
            Items = items;

        public IEnumerable<Item> Items { get; }
    }
}
