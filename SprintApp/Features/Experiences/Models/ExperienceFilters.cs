namespace SprintApp.Features.Experiences.Models;

public enum ExperienceSort { Recommended, PriceAscending, PriceDescending, DurationAscending }

public sealed class ExperienceFilters
{
    public string Search { get; set; } = "";
    public string DestinationId { get; set; } = "";
    public ExperienceType? Type { get; set; }
    public int MaxPrice { get; set; } = 100;
    public int Guests { get; set; } = 1;
    public double MaxHours { get; set; } = 3;
    public bool PristineSkies { get; set; }
    public bool SavedOnly { get; set; }
    public ExperienceSort Sort { get; set; }

    public bool HasFilters => !string.IsNullOrWhiteSpace(Search) || DestinationId.Length > 0
        || Type.HasValue || MaxPrice < 100 || Guests > 1 || MaxHours < 3 || PristineSkies || SavedOnly;
}
