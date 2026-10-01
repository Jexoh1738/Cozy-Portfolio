namespace CozyPortfolio.Services;

public interface IAudioService : IAsyncDisposable
{
    bool IsMuted { get; }
    double Volume { get; }
    event Action? MuteStateChanged;

    Task InitializeAsync();
    Task PlayMoodTrackAsync(string audioPath);
    Task SetVolumeAsync(double volume);
    Task<bool> TogglePreviewAsync(string audioPath);
    Task StopPreviewAsync();
    Task ToggleMuteAsync();
}