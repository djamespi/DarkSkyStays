namespace SprintApp.Features.SavedTrips.Models;

public enum SavedItemType { Stay, Experience }

public sealed record SavedTrip(string ItemId, SavedItemType ItemType, DateTimeOffset SavedAt);
