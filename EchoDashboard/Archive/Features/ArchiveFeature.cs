using Archive.Models;
using EchoDashboard.Shared;
using Fluxor;

namespace Archive.Features
{
    internal class ArchiveFeature : Feature<ArchiveState>
    {
        public override string GetName() => nameof(ArchiveFeature);

        protected override ArchiveState GetInitialState() =>
            new ArchiveState(false, Array.Empty<string>(), Array.Empty<WeatherForecast>());
    }
}
