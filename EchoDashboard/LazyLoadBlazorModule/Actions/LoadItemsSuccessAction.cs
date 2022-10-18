using LazyLoadBlazorModule.Models;

namespace LazyLoadBlazorModule.Actions
{
    public class LoadItemsSuccessAction
    {
        public LoadItemsSuccessAction(IEnumerable<Item> items) =>
            Items = items ?? Array.Empty<Item>();

        public IEnumerable<Item> Items { get; }
    }
}
