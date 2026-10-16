using System.ComponentModel.DataAnnotations;
using SprintApp.Features.Experiences.Data;
using SprintApp.Features.Experiences.Models;

namespace SprintApp.Features.Experiences.Services;

/// <summary>Creates in-memory demonstrations only. No reservations, payments, or emails.</summary>
public sealed class DemoBookingService
{
    private readonly List<DemoBookingConfirmation> confirmations = [];
    public IReadOnlyList<DemoBookingConfirmation> Confirmations => confirmations.AsReadOnly();

    // The sprint is run in Singapore. Derive its date independently of the server's timezone.
    public DateOnly Today => DateOnly.FromDateTime(DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(8)).DateTime);
    public DateOnly LastBookableNight => Today.AddYears(1);

    public bool TryCreate(string experienceId, DemoBookingRequest request,
        out DemoBookingConfirmation? confirmation, out IReadOnlyDictionary<string, string> errors)
    {
        var messages = new Dictionary<string, string>();
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(request, new ValidationContext(request), results, validateAllProperties: true);
        foreach (var result in results)
            foreach (var member in result.MemberNames)
                messages.TryAdd(member, result.ErrorMessage ?? "Check this field.");

        var experience = SampleExperiences.All.FirstOrDefault(item => item.Id == experienceId);
        if (experience is null) messages[""] = "This experience is no longer in the sample collection.";
        if (request.Night is not null)
        {
            var night = DateOnly.FromDateTime(request.Night.Value);
            if (night < Today || night > LastBookableNight)
                messages[nameof(request.Night)] = "Choose a night from today through the next year.";
        }
        if (experience is not null && request.Guests > experience.MaxParticipants)
            messages[nameof(request.Guests)] = $"This small-group experience welcomes up to {experience.MaxParticipants} guests.";
        var guestName = request.Name?.Trim() ?? "";
        if (guestName.Length < 2)
            messages.TryAdd(nameof(request.Name), "Use a name with at least 2 characters.");

        errors = messages;
        confirmation = null;
        if (messages.Count > 0) return false;

        confirmation = new DemoBookingConfirmation(
            $"DS-{Guid.NewGuid().ToString("N")[..8].ToUpperInvariant()}", experience!.Id,
            experience.Name, experience.Destination.DisplayName, DateOnly.FromDateTime(request.Night!.Value),
            request.Guests, experience.PricePerPerson, guestName, request.Email.Trim(), DateTimeOffset.UtcNow);
        confirmations.Add(confirmation);
        return true;
    }
}
