using SprintApp.Features.Discovery.Models;
using SprintApp.Features.Sky.Models;

namespace SprintApp.Features.Experiences.Models;

public enum ExperienceType { Stargazing, Astrophotography, NightWalk }

public sealed record TourExperience(
    string Id, string Name, Destination Destination, ExperienceType Type,
    string Description, decimal PricePerPerson, double DurationHours,
    int MaxParticipants, double Rating, string ImageUrl, string GuideName,
    SkyConditions Sky, IReadOnlyList<string> Includes);
