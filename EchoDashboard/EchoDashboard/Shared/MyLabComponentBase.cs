using EchoDashboard.Shared.Facades;
using EchoDashboard.Shared.States;
using EchoDashboard.Shared.Store;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace EchoDashboard.Shared
{
    public abstract class MyLabComponentBase<TState, TFacade, TStoreInitializer> : FluxorComponent
        where TState : BaseState
        where TFacade : StateFacade<TState, TFacade, TStoreInitializer>
        where TStoreInitializer : IStoreInitializer<TState>
    {
        #region Data Members

        private readonly string _componentKey;

        #endregion

        #region Constructors

        protected MyLabComponentBase(string componentKey)
        {
            _componentKey = componentKey;
        }

        #endregion

        #region Properties

        [Inject]
        IServiceProvider? ServiceProvider { get; set; }

        [Inject]
        IStore? Store { get; set; }

        [Inject]
        StateFacadeRegistry? StateFacadeRegistry { get; set; }

        [Inject]
        ILogger<MyLabComponentBase<TState, TFacade, TStoreInitializer>>? Logger { get; set; }

        protected TState? State => Store!.Features[_componentKey]?.GetState() as TState;

        protected TFacade? Facade => StateFacadeRegistry!.GetFacade<TFacade>(_componentKey);

        #endregion

        #region Protected Functions

        sealed async protected override Task OnInitializedAsync()
        {
            OnInitializeFacade();

            await OnInitializeComponentAsync();

            await base.OnInitializedAsync();
        }

        virtual protected Task OnInitializeComponentAsync() { return Task.CompletedTask; }

        #endregion

        #region Private Functions

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

        private TFacade BuildFacade()
        {
            return Activator.CreateInstance<TFacade>();
        }

        #endregion
    }
}
