namespace SprintApp.Features.Stays.Models;

public enum StaySort { Recommended, PriceAscending, PriceDescending, DarkestSkies, HighestRated }

public sealed class StayFilters
{
    public string Search { get; set; } = "";
    public string DestinationId { get; set; } = "";
    public StayType? Type { get; set; }
    public int Guests { get; set; } = 1;
    public int MaxPrice { get; set; } = 350;
    public int MaxBortle { get; set; } = 9;
    public bool LowMoonlight { get; set; }
    public bool SavedOnly { get; set; }
    public StaySort Sort { get; set; }

    public bool HasFilters => !string.IsNullOrWhiteSpace(Search) || DestinationId.Length > 0
        || Type.HasValue || Guests > 1 || MaxPrice < 350 || MaxBortle < 9 || LowMoonlight || SavedOnly;
}
