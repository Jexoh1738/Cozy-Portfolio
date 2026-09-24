using CozyPortfolio.Models;

namespace CozyPortfolio.Services;

public class PortfolioDataService : IPortfolioDataService
{
    private readonly List<Project> _projects = new()
    {
        new Project("Cozy Weather", "A warm, minimal weather dashboard showing hourly forecasts, UV index, and mood-matched wallpapers.", new[] { "Blazor WASM", "C#", ".NET 8" }, IconName.Sun),
        new Project("Pixel Garden", "Procedurally generated pixel-art gardens. Grow plants, earn seeds, water neighbors' plots in real time.", new[] { "C#", "SignalR", "HTML Canvas" }, IconName.Sparkle),
        new Project("Note Nook", "A warm-toned note-taking app with rich text editing, tagging, and daily journal prompts.", new[] { "Blazor Server", "SQLite", "EF Core" }, IconName.Pin)
    };

    private readonly List<Skill> _skills = new()
    {
        new Skill("C# / .NET 8", IconName.Code),
        new Skill("Blazor WebAssembly", IconName.Globe),
        new Skill("HTML & CSS", IconName.Layers),
        new Skill("TypeScript", IconName.FileCode),
        new Skill("SQL & EF Core", IconName.Database),
        new Skill("Git & GitHub", IconName.GitBranch),
        new Skill("Python", IconName.Terminal),
        new Skill("Java", IconName.Wrench)
    };

    private readonly List<MoodState> _moodStates = new()
    {
        new MoodState("Happy", "Welcome to my cozy corner of the internet! I'm so glad you stopped by~", "images/mascot/happy.jpg", "bg-blush border-coral/30", IconName.Sun, "audio/happy.mp3"),
        new MoodState("Sleepy", "...oh! You came to visit? Excuse me, I was just resting...", "images/mascot/sleepy.jpg", "bg-powder border-sky/40", IconName.Sparkle, "audio/sleepy.mp3"),
        new MoodState("Cool", "Hey. Cool of you to stop by. Check out what I've been building lately.", "images/mascot/cool.jpg", "bg-mint border-sage/40", IconName.BotMessageSquare, "audio/cool.mp3")
    };

    public IReadOnlyList<Project> GetProjects() => _projects;
    public IReadOnlyList<Skill> GetSkills() => _skills;
    public IReadOnlyList<MoodState> GetMoodStates() => _moodStates;
}