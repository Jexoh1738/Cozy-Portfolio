namespace CozyPortfolio.Services;

public interface IAudioService : IAsyncDisposable
{
    bool IsMuted { get; }
    double Volume { get; }
    event Action? MuteStateChanged;

    Task InitializeAsync();
    Task PlayMoodTrackAsync(string audioPath);
    Task SetVolumeAsync(double volume);
    Task ToggleMuteAsync();
}