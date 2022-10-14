using EchoDashboard.Shared.States;
using Fluxor;

namespace EchoDashboard.Shared.Store
{
    public abstract class StoreInitializer<TState> : IStoreInitializer<TState>
        where TState : BaseState
    {
        #region Data Members

        private readonly IStore? _store;
        private readonly IServiceProvider? _serviceProvider;

        #endregion

        #region Constructors

        public StoreInitializer(IStore store, IServiceProvider serviceProvider) =>
            (_store, _serviceProvider) = (store, serviceProvider);

        #endregion

        #region Public Functions

        public void Initialize()
        {
            var feature = BuildFeature(_serviceProvider);
            var reducers = BuildReducers(_serviceProvider);
            reducers
                .ToList()
                .ForEach(reducer => feature.AddReducer(reducer));

            _store!.AddFeature(feature);

            var effects = BuildEffects(_serviceProvider);
            effects
                .ToList()
                .ForEach(effect => _store!.AddEffect(effect));
        }

        #endregion

        #region Protected Functions

        abstract protected IFeature<TState> BuildFeature(IServiceProvider? serviceProvider);

        virtual protected IEnumerable<IReducer<TState>> BuildReducers(IServiceProvider? serviceProvider) =>
                        Array.Empty<IReducer<TState>>();

        virtual protected IEnumerable<IEffect> BuildEffects(IServiceProvider? serviceProvider) =>
            Array.Empty<IEffect>();

        #endregion
    }
}
