using SprintApp.Features.SavedTrips.Models;
using SprintApp.Features.SavedTrips.Services;
using SprintApp.Features.Stays.Data;
using SprintApp.Features.Stays.Models;

namespace SprintApp.Features.Stays.Services;

public sealed class StaySearchService(SavedTripsService savedTrips)
{
    public IReadOnlyList<Stay> Search(StayFilters filters)
    {
        var text = filters.Search.Trim();
        var matches = SampleStays.All.Where(stay =>
            (text.Length == 0 || stay.Name.Contains(text, StringComparison.OrdinalIgnoreCase)
                || stay.Destination.DisplayName.Contains(text, StringComparison.OrdinalIgnoreCase)
                || stay.Amenities.Any(amenity => amenity.Contains(text, StringComparison.OrdinalIgnoreCase)))
            && (filters.DestinationId.Length == 0 || stay.Destination.Id == filters.DestinationId)
            && (!filters.Type.HasValue || stay.Type == filters.Type)
            && stay.MaxGuests >= filters.Guests
            && stay.PricePerNight <= filters.MaxPrice
            && stay.Sky.BortleClass <= filters.MaxBortle
            && (!filters.LowMoonlight || stay.Sky.MoonIlluminationPercent <= 15)
            && (!filters.SavedOnly || savedTrips.Contains(stay.Id, SavedItemType.Stay)));

        return (filters.Sort switch
        {
            StaySort.PriceAscending => matches.OrderBy(stay => stay.PricePerNight),
            StaySort.PriceDescending => matches.OrderByDescending(stay => stay.PricePerNight),
            StaySort.DarkestSkies => matches.OrderBy(stay => stay.Sky.BortleClass).ThenBy(stay => stay.Sky.MoonIlluminationPercent),
            StaySort.HighestRated => matches.OrderByDescending(stay => stay.Rating),
            _ => matches.OrderBy(stay => stay.Sky.BortleClass).ThenByDescending(stay => stay.Rating)
        }).ToArray();
    }
}
