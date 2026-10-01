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
        new MoodState("Happy", "Welcome to my cozy corner of the internet! I'm so glad you stopped by~", "images/mascot/happy.jpg", "bg-blush border-coral/30", IconName.Sun, "audio/moods/happy.mp3"),
        new MoodState("Sleepy", "...oh! You came to visit? Excuse me, I was just resting...", "images/mascot/sleepy.jpg", "bg-powder border-sky/40", IconName.Sparkle, "audio/moods/sleepy.mp3"),
        new MoodState("Cool", "Hey. Cool of you to stop by. Check out what I've been building lately.", "images/mascot/cool.jpg", "bg-mint border-sage/40", IconName.BotMessageSquare, "audio/moods/cool.mp3"),
        new MoodState("Hype", "Nothing beats a house music special. I feel like I can code all day!", "images/mascot/hype.jpg", "bg-[#ffd6a5] border-[#f59e0b]/50", IconName.Energy, "audio/moods/hype.mp3")
    };

    private readonly List<Album> _albums = new()
    {
        new Album("shut-up-and-drive", "Be Quiet And Drive (Far Away)", "Deftones", 1997, "Alternative Metal",
            "images/albums/shut-up-drive.png", "audio/snippets/shut-up-and-drive.mp3", "rgba(90,168,245,0.55)", "rgba(200,232,255,0.45)"),
        new Album("weird-fishes", "All I Need", "Radiohead", 2007, "Art Rock / Alternative",
            "images/albums/all-i-need.png", "audio/snippets/all-i-need.mp3", "rgba(90,168,245,0.55)", "rgba(200,232,255,0.45)"),
        new Album("the-boy", "The Boy", "The Smashing Pumpkins", 1996, "Alternative Rock",
            "images/albums/the-boy.jpg", "audio/snippets/the-boy.mp3", "rgba(90,168,245,0.55)", "rgba(200,232,255,0.45)"),
        new Album("through-the-dark", "Through the Dark", "The Sundays", 1997, "Jangle Pop / Indie Pop",
            "images/albums/through-the-dark.jpg", "audio/snippets/through-the-dark.mp3", "rgba(90,168,245,0.55)", "rgba(200,232,255,0.45)"),
        new Album("she-smokes-in-bed", "She Smokes in Bed", "TV Girl", 2015, "Indie Pop",
            "images/albums/she-smokes.jpg", "audio/snippets/she-smokes-in-bed.mp3", "rgba(90,168,245,0.55)", "rgba(200,232,255,0.45)"),
        new Album("frou-frou", "Frou-Frou Foxes in Midsummer Fires", "Cocteau Twins", 1990, "Dream Pop / Shoegaze",
            "images/albums/frou-frou.png", "audio/snippets/frou-frou.mp3", "rgba(90,168,245,0.55)", "rgba(200,232,255,0.45)"),
        new Album("champagne-coast", "Champagne Coast", "Blood Orange", 2011, "Alternative R&B",
            "images/albums/champagne-coast.jpg", "audio/snippets/champagne-coast.mp3", "rgba(90,168,245,0.55)", "rgba(200,232,255,0.45)"),
        new Album("aoi-koi-daidaiiro", "青い、濃い、橙色の日", "Mass of the Fermenting Dregs", 2009, "Post-Hardcore / Shoegaze",
            "images/albums/aoi-koi.png", "audio/snippets/aoi-koi-daidaiiro.mp3", "rgba(90,168,245,0.55)", "rgba(200,232,255,0.45)"),
        new Album("clarity", "Clarity", "Zedd", 2012, "EDM / Dance Pop",
            "images/albums/clarity.jpg", "audio/snippets/clarity.mp3", "rgba(90,168,245,0.55)", "rgba(200,232,255,0.45)"),
        new Album("touch", "Touch", "Cigarettes After Sex", 2019, "Dream Pop",
            "images/albums/touch.jpg", "audio/snippets/touch.mp3", "rgba(90,168,245,0.55)", "rgba(200,232,255,0.45)"),
        new Album("isang-pag-ibig", "Isang Pag ibig", "IV Of Spades", 2026, "OPM / Funk Rock",
            "images/albums/isang-pagibig.jpg", "audio/snippets/isang-pag-ibig.mp3", "rgba(90,168,245,0.55)", "rgba(200,232,255,0.45)"),
        new Album("fallingforyou", "fallingforyou", "The 1975", 2013, "Indie Pop / Synth-Pop",
            "images/albums/fallingforyou.png", "audio/snippets/fallingforyou.mp3", "rgba(90,168,245,0.55)", "rgba(200,232,255,0.45)")
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