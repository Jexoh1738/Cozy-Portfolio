namespace CozyPortfolio.Services;
using CozyPortfolio.Models;

public interface IPortfolioDataService
{
    IReadOnlyList<Project> GetProjects();
    IReadOnlyList<Skill> GetSkills();
    IReadOnlyList<MoodState> GetMoodStates();

    IReadOnlyList<Album> GetAlbums();
    IReadOnlyList<Review> GetReviews(string albumId);
    Review AddReview(string albumId, string? author, int rating, string comment);
}