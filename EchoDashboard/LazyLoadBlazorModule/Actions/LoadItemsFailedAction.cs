namespace LazyLoadBlazorModule.Actions
{
    public class LoadItemsFailedAction
    {
        public LoadItemsFailedAction(string errorMessage) =>
            ErrorMessage = errorMessage;

        public string ErrorMessage { get; }
    }
}
