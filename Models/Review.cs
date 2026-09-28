namespace CozyPortfolio.Models;

public record Review(Guid Id, string AlbumId, string Author, int Rating, string Comment, DateTime PostedAt);