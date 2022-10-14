namespace Counter.Actions
{
    public class IncreaseCounterAction
    {
        public IncreaseCounterAction(int value)
            => Value = value;

        public int Value { get; }
    }
}
