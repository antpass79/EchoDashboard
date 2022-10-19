using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Platform.Frontend.Framework.Facades;
using Platform.Frontend.Framework.Store;

namespace Platform.Frontend.Framework
{
    public abstract class BasePageComponent<TState, TFacade, TStoreInitializer> : FluxorComponent
        where TState : BaseState
        where TFacade : StateFacade<TState, TFacade, TStoreInitializer>
        where TStoreInitializer : IStoreInitializer<TState>
    {
        #region Data Members

        private readonly string _componentKey;

        #endregion

        #region Constructors

        protected BasePageComponent(string componentKey)
        {
            _componentKey = componentKey;
        }

        #endregion

        #region Properties

        [Inject]
        IServiceProvider? ServiceProvider { get; set; }

        [Inject]
        protected IStore? Store { get; set; }

        [Inject]
        StateFacadeRegistry? StateFacadeRegistry { get; set; }

        [Inject]
        ILogger<BasePageComponent<TState, TFacade, TStoreInitializer>>? Logger { get; set; }

        protected TState? State => Store!.Features[_componentKey]?.GetState() as TState;

        protected TFacade? Facade => StateFacadeRegistry!.GetFacade<TFacade>(_componentKey);

        #endregion

        #region Protected Functions

        sealed async protected override Task OnInitializedAsync()
        {
            OnInitializeFacade();

            OnUpdateState();

            await OnInitializeComponentAsync();

            await base.OnInitializedAsync();
        }

        virtual protected TFacade BuildFacade()
        {
            return Activator.CreateInstance<TFacade>();
        }

        virtual protected Task OnInitializeComponentAsync() { return Task.CompletedTask; }

        protected override void Dispose(bool disposing)
        {
            var feature = Store!.Features[_componentKey];
            feature.StateChanged -= OnFeatureStateChanged;

            base.Dispose(disposing);
        }

        #endregion

        #region Private Functions

        private void OnUpdateState()
        {
            var feature = Store!.Features[_componentKey];
            feature.StateChanged += OnFeatureStateChanged;
        }

        void OnFeatureStateChanged(object? sender, EventArgs args)
        {
            StateHasChanged();
        }

        void OnInitializeFacade()
        {
            if (FacadeInitialized())
                return;

            Logger!.LogInformation($"The component {GetType().Name} is initialized");

            var facade = BuildFacade();
            facade.InjectUniqueKey(_componentKey);
            facade.InjectServiceProvider(ServiceProvider!);
            StateFacadeRegistry!.RegisterFacade(_componentKey, facade);
        }

        private bool FacadeInitialized()
        {
            return StateFacadeRegistry!.Exists(_componentKey);
        }

        #endregion
    }
}
