using Archive.Models;
using Fluxor;

namespace Archive.Features
{
    internal class ArchiveFeature : Feature<ArchiveState>
    {
        public override string GetName() => nameof(ArchiveState);

        protected override ArchiveState GetInitialState() =>
            new ArchiveState(false, Array.Empty<string>(), Array.Empty<WeatherForecast>());
    }
}
