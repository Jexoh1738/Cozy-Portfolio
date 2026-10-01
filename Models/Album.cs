namespace CozyPortfolio.Models;

public record Album(
    string Id,
    string Title,
    string Artist,
    int Year,
    string Genre,
    string CoverImagePath,
    string GlowColor,
    string GlossTint);