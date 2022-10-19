using LazyLoadBlazorModule.Models;
using Platform.Frontend.Framework;

namespace LazyLoadBlazorModule
{
    public class LazyLoadBlazorModuleState : BaseState
    {
        public LazyLoadBlazorModuleState(bool isLoading, IEnumerable<string> errorMessages, IEnumerable<Item> items)
            : base(isLoading, errorMessages) =>
            Items = items;

        public IEnumerable<Item> Items { get; init;  }
    }
}
