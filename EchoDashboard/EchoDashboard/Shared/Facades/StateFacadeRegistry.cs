namespace EchoDashboard.Shared.Facades
{
    public class StateFacadeRegistry
    {
        #region Data Members

        Dictionary<string, IStateFacade> _facades = new Dictionary<string, IStateFacade>();

        #endregion

        #region Public Functions

        public T? GetFacade<T>(string key)
            where T : class, IStateFacade
        {
            return _facades[key] as T;
        }

        public void RegisterFacade(string key, IStateFacade facade)
        {
            _facades.Add(key, facade);
        }

        public void Unregister(string key)
        {
            _facades.Remove(key);
        }

        public bool Exists(string key)
        {
            return _facades.ContainsKey(key);
        }

        #endregion
    }
}
