namespace MyLab.Platform.Frontend.Framework
{
    public abstract class BaseState
    {
        protected BaseState(bool isLoading, IEnumerable<string> errorMessages)
        {
            IsLoading = isLoading;
            ErrorMessages = errorMessages;
        }

        public bool IsLoading { get; }
        public IEnumerable<string> ErrorMessages { get; }
        public bool HasErrors => ErrorMessages.Any();
    }
}
