using MyLab.Platform.Frontend.Framework;

namespace Counter
{
    public class CounterState : BaseState
    {
        public CounterState()
            : base(false, Array.Empty<string>()) { }

        public CounterState(bool isLoading, IEnumerable<string> errorMessages, int value)
            : base(isLoading, errorMessages) => Value = value;

        public int Value { get; } = 0;
    }
}
