using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyLab.Platform.Frontend.Framework.Store;

namespace MyLab.Platform.Frontend.Framework.Facades
{
    public abstract class StateFacade<TState, TFacade, TStoreInitializer> : IStateFacade
        where TState : BaseState
        where TFacade : StateFacade<TState, TFacade, TStoreInitializer>
        where TStoreInitializer : IStoreInitializer<TState>
    {
        #region Data Members

        private string? _featureName;

        #endregion

        #region Properties

        ILogger<StateFacade<TState, TFacade, TStoreInitializer>>? Logger { get; set; }
        protected IDispatcher? Dispatcher { get; private set; }

        IStore? Store { get; set; }

        #endregion

        #region Internal Functions

        internal void InjectServiceProvider(IServiceProvider serviceProvider)
        {
            Logger = serviceProvider.GetRequiredService<ILogger<StateFacade<TState, TFacade, TStoreInitializer>>>();
            Dispatcher = serviceProvider.GetRequiredService<IDispatcher>();
            Store = serviceProvider.GetRequiredService<IStore>();

            OnServiceProviderInjected(serviceProvider);
            OnInitializeStore(serviceProvider);
        }

        internal void InjectUniqueKey(string key)
        {
            _featureName = key;
        }

        #endregion

        #region Protected Functions

        virtual protected void OnServiceProviderInjected(IServiceProvider serviceProvider)
        {
        }

        #endregion

        #region Private Functions

        private void OnInitializeStore(IServiceProvider serviceProvider)
        {
            if (StoreInitialized())
                return;

            Logger!.LogInformation($"The facade {GetType().Name} is initialized");

            var storeInitializer = Activator.CreateInstance(
                typeof(TStoreInitializer),
                Store,
                serviceProvider) as IStoreInitializer<TState>;
            
            storeInitializer?
                .Initialize();
        }

        private bool StoreInitialized()
        {
            return Store!.Features.Any(feature => feature.Key == _featureName);
        }

        #endregion
    }
}
