using Microsoft.JSInterop;

namespace CozyPortfolio.Services;

public class AudioService : IAudioService
{
    private const int CrossfadeDurationMs = 900;

    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _module;

    public AudioService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public bool IsMuted { get; private set; }
    public double Volume { get; private set; } = 0.2;
    public event Action? MuteStateChanged;

    private async Task<IJSObjectReference> GetModuleAsync()
    {
        // Imported once and cached — this is the JS isolation pattern:
        // the module is never exposed on window, only reachable through this reference.
        _module ??= await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/audio.js");
        return _module;
    }

    public async Task InitializeAsync()
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("init");
    }

    public async Task PlayMoodTrackAsync(string audioPath)
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("crossfadeTo", audioPath, CrossfadeDurationMs);
    }

    public async Task SetVolumeAsync(double volume)
    {
        Volume = Math.Clamp(volume, 0, 0.5);
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("setVolume", Volume);
        MuteStateChanged?.Invoke();
    }

    public async Task<bool> TogglePreviewAsync(string audioPath)
    {
        var module = await GetModuleAsync();
        return await module.InvokeAsync<bool>("togglePreview", audioPath);
    }

    public async Task StopPreviewAsync()
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("stopPreview");
    }

    public async Task ToggleMuteAsync()
    {
        IsMuted = !IsMuted;
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("setMuted", IsMuted);
        MuteStateChanged?.Invoke();
    }

    public async ValueTask DisposeAsync()
    {
        if (_module is not null)
        {
            await _module.InvokeVoidAsync("dispose");
            await _module.DisposeAsync();
        }
    }
}