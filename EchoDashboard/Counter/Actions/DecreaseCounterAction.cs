namespace Counter.Actions
{
    public class DecreaseCounterAction
    {
        public DecreaseCounterAction(int value)
            => Value = value;

        public int Value { get; }
    }
}
