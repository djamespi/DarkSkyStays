using SprintApp.Features.Experiences.Data;
using SprintApp.Features.Experiences.Models;
using SprintApp.Features.SavedTrips.Models;
using SprintApp.Features.SavedTrips.Services;

namespace SprintApp.Features.Experiences.Services;

public sealed class ExperienceSearchService(SavedTripsService savedTrips)
{
    public IReadOnlyList<TourExperience> Search(ExperienceFilters filters)
    {
        var text = filters.Search.Trim();
        var matches = SampleExperiences.All.Where(experience =>
            (text.Length == 0 || experience.Name.Contains(text, StringComparison.OrdinalIgnoreCase)
                || experience.Destination.DisplayName.Contains(text, StringComparison.OrdinalIgnoreCase)
                || experience.GuideName.Contains(text, StringComparison.OrdinalIgnoreCase)
                || experience.Includes.Any(item => item.Contains(text, StringComparison.OrdinalIgnoreCase)))
            && (filters.DestinationId.Length == 0 || experience.Destination.Id == filters.DestinationId)
            && (!filters.Type.HasValue || experience.Type == filters.Type)
            && experience.PricePerPerson <= filters.MaxPrice
            && experience.MaxParticipants >= filters.Guests
            && experience.DurationHours <= filters.MaxHours
            && (!filters.PristineSkies || experience.Sky.BortleClass == 1)
            && (!filters.SavedOnly || savedTrips.Contains(experience.Id, SavedItemType.Experience)));

        return (filters.Sort switch
        {
            ExperienceSort.PriceAscending => matches.OrderBy(experience => experience.PricePerPerson),
            ExperienceSort.PriceDescending => matches.OrderByDescending(experience => experience.PricePerPerson),
            ExperienceSort.DurationAscending => matches.OrderBy(experience => experience.DurationHours),
            _ => matches.OrderByDescending(experience => experience.Rating)
        }).ToArray();
    }
}
