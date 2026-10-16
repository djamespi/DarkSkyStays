using SprintApp.Features.Discovery.Models;
using SprintApp.Features.Sky.Models;

namespace SprintApp.Features.Stays.Models;

public enum StayType { Cabin, Dome, Glamping }

public sealed record Stay(
    string Id, string Name, Destination Destination, StayType Type,
    string Description, decimal PricePerNight, double Rating, int ReviewCount,
    int MaxGuests, string ImageUrl, string ImageDescription,
    SkyConditions Sky, IReadOnlyList<string> Amenities);
