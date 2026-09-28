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

    private readonly List<Album> _albums = new()
    {
        new Album("blue-rev", "Blue Rev", "Alvvays", 2022, "Dream Pop / Indie Rock",
            "linear-gradient(145deg, #5ba8f5 0%, #90c8ff 45%, #c4e4ff 75%, #ddf0ff 100%)", "rgba(90,168,245,0.55)", "rgba(200,232,255,0.45)"),
        new Album("antisocialites", "Antisocialites", "Alvvays", 2017, "Indie Pop",
            "linear-gradient(145deg, #ff8c38 0%, #ffb347 45%, #ffd580 75%, #ffe8a8 100%)", "rgba(255,140,56,0.55)", "rgba(255,224,160,0.45)"),
        new Album("get-up", "Get Up", "NewJeans", 2023, "K-Pop / Bedroom Pop",
            "linear-gradient(145deg, #00c896 0%, #40e0b8 45%, #90f5d8 75%, #c0fff0 100%)", "rgba(0,200,150,0.55)", "rgba(160,255,224,0.45)"),
        new Album("omg", "OMG", "NewJeans", 2023, "K-Pop / Dance Pop",
            "linear-gradient(145deg, #a855f7 0%, #c87af0 45%, #e0a8ff 75%, #f0d0ff 100%)", "rgba(168,85,247,0.55)", "rgba(224,192,255,0.45)"),
        new Album("heaven-or-las-vegas", "Heaven or Las Vegas", "Cocteau Twins", 1990, "Dream Pop / Shoegaze",
            "linear-gradient(145deg, #00b4d8 0%, #00d4f0 45%, #60eeff 75%, #b0f8ff 100%)", "rgba(0,180,216,0.55)", "rgba(160,240,255,0.45)"),
        new Album("treasure", "Treasure", "Cocteau Twins", 1984, "Dream Pop / Post-Punk",
            "linear-gradient(145deg, #2d9e5f 0%, #3fc878 45%, #80e0a0 75%, #b8f0c8 100%)", "rgba(45,158,95,0.55)", "rgba(160,240,192,0.45)"),
        new Album("reading-writing-arithmetic", "Reading, Writing and Arithmetic", "The Sundays", 1990, "Jangle Pop / Dream Pop",
            "linear-gradient(145deg, #f472b6 0%, #f9a8d4 45%, #fbcfe8 75%, #fdf2f8 100%)", "rgba(244,114,182,0.55)", "rgba(252,207,232,0.45)"),
        new Album("static-and-silence", "Static & Silence", "The Sundays", 1997, "Indie Pop",
            "linear-gradient(145deg, #f5c542 0%, #f8d878 45%, #fbe6a0 75%, #fef3c7 100%)", "rgba(245,197,66,0.55)", "rgba(254,240,180,0.45)")
    };

    private readonly List<Review> _reviews = new()
    {
        new Review(Guid.NewGuid(), "blue-rev", "Mio", 5, "Feels like standing in a field of silvergrass in autumn. Belinda Says is on repeat.", new DateTime(2026, 9, 12)),
        new Review(Guid.NewGuid(), "blue-rev", "Kev", 4, "Dreamy and dense. Pharmacist is such a perfect single.", new DateTime(2026, 8, 3)),
        new Review(Guid.NewGuid(), "get-up", "Sora", 5, "Every track is a perfect confection. Super Shy alone is worth it.", new DateTime(2026, 7, 22)),
        new Review(Guid.NewGuid(), "heaven-or-las-vegas", "Ren", 5, "Hauntingly beautiful. Cherry-Coloured Funk is ethereal.", new DateTime(2026, 6, 5)),
        new Review(Guid.NewGuid(), "heaven-or-las-vegas", "Mio", 5, "Peak dream pop. The production still sounds otherworldly decades later.", new DateTime(2026, 5, 18)),
        new Review(Guid.NewGuid(), "reading-writing-arithmetic", "Kev", 4, "Here's Where the Story Ends is a whole mood in three minutes.", new DateTime(2026, 4, 9))
    };

    public IReadOnlyList<Project> GetProjects() => _projects;
    public IReadOnlyList<Skill> GetSkills() => _skills;
    public IReadOnlyList<MoodState> GetMoodStates() => _moodStates;

    public IReadOnlyList<Album> GetAlbums() => _albums;

    public IReadOnlyList<Review> GetReviews(string albumId) =>
        _reviews.Where(r => r.AlbumId == albumId)
                .OrderByDescending(r => r.PostedAt)
                .ToList();

    public Review AddReview(string albumId, string? author, int rating, string comment)
    {
        if (_albums.All(a => a.Id != albumId))
            throw new ArgumentException($"Unknown album '{albumId}'.", nameof(albumId));
        if (rating is < 1 or > 5)
            throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be between 1 and 5.");
        if (string.IsNullOrWhiteSpace(comment))
            throw new ArgumentException("Comment cannot be empty.", nameof(comment));

        var review = new Review(
            Guid.NewGuid(),
            albumId,
            string.IsNullOrWhiteSpace(author) ? "Anonymous" : author.Trim(),
            rating,
            comment.Trim(),
            DateTime.Now);

        _reviews.Add(review);
        return review;
    }
}