namespace Platform.Frontend.Framework
{
    public abstract class BaseState
    {
        protected BaseState(bool isLoading, IEnumerable<string> errorMessages)
        {
            IsLoading = isLoading;
            ErrorMessages = errorMessages;
        }

        public bool IsLoading { get; init;  }
        public IEnumerable<string> ErrorMessages { get; init; }
        public bool HasErrors => ErrorMessages.Any();
    }
}
