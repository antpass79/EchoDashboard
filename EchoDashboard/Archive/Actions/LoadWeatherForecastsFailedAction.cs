namespace Archive.Actions
{
    public class LoadWeatherForecastsFailedAction
    {
        public LoadWeatherForecastsFailedAction(string errorMessage) =>
            ErrorMessage = errorMessage;

        public string ErrorMessage { get; }
    }
}
