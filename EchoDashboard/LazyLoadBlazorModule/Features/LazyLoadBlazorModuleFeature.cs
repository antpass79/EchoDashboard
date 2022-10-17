using Fluxor;
using LazyLoadBlazorModule.Models;

namespace LazyLoadBlazorModule.Features
{
    internal class LazyLoadBlazorModuleFeature : Feature<LazyLoadBlazorModuleState>
    {
        public override string GetName() => nameof(LazyLoadBlazorModuleFeature);

        protected override LazyLoadBlazorModuleState GetInitialState() =>
            new LazyLoadBlazorModuleState(false, Array.Empty<string>(), Array.Empty<Item>());
    }
}
