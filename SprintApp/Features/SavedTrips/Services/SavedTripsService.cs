using SprintApp.Features.SavedTrips.Models;

namespace SprintApp.Features.SavedTrips.Services;

/// <summary>A visitor's in-memory collection. Scoped to their Blazor circuit.</summary>
public sealed class SavedTripsService
{
    private readonly Dictionary<(SavedItemType Type, string Id), SavedTrip> items = [];

    public event Action? Changed;
    public IReadOnlyCollection<SavedTrip> Items => items.Values.ToArray();
    public int StayCount => items.Keys.Count(key => key.Type == SavedItemType.Stay);
    public int Count => items.Count;

    public bool Contains(string id, SavedItemType type) => items.ContainsKey((type, id));

    public bool Toggle(string id, SavedItemType type)
    {
        var key = (type, id);
        var added = !items.Remove(key);
        if (added)
        {
            items.Add(key, new SavedTrip(id, type, DateTimeOffset.UtcNow));
        }

        Changed?.Invoke();
        return added;
    }
}
