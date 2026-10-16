using System.Globalization;
using System.Text;
using SprintApp.Features.Experiences.Data;
using SprintApp.Features.Experiences.Models;
using SprintApp.Features.SavedTrips.Models;
using SprintApp.Features.Stays.Data;

namespace SprintApp.Features.SavedTrips.Services;

public static class TripNotesBuilder
{
    public static string Build(IEnumerable<SavedTrip> favorites, IReadOnlyList<DemoBookingConfirmation> bookings)
    {
        var items = favorites.ToArray();
        var text = new StringBuilder();
        text.AppendLine("DARK SKY STAYS | YOUR LITTLE COLLECTION")
            .AppendLine("Less light. More wonder.")
            .AppendLine()
            .AppendLine("DEMO ONLY: fictional listings, rates, ratings, and sky conditions.")
            .AppendLine("No reservation, payment, or email has been made. All prices are USD.")
            .AppendLine()
            .AppendLine("SAVED STAYS (sample nightly rates)");

        var stays = SampleStays.All.Where(stay => items.Any(item => item.ItemType == SavedItemType.Stay && item.ItemId == stay.Id)).ToArray();
        if (stays.Length == 0) text.AppendLine("None saved yet.");
        foreach (var stay in stays)
            text.AppendLine($"- {stay.Name} | {stay.Destination.DisplayName}")
                .AppendLine($"  ${stay.PricePerNight.ToString("0", CultureInfo.InvariantCulture)} / night | Up to {stay.MaxGuests} guests")
                .AppendLine($"  Sample sky: Bortle {stay.Sky.BortleClass}, {stay.Sky.MoonPhaseLabel}, {stay.Sky.MoonIlluminationPercent}% illuminated.");

        text.AppendLine().AppendLine("SAVED EXPERIENCES (sample prices per person)");
        var experiences = SampleExperiences.All.Where(experience => items.Any(item => item.ItemType == SavedItemType.Experience && item.ItemId == experience.Id)).ToArray();
        if (experiences.Length == 0) text.AppendLine("None saved yet.");
        foreach (var experience in experiences)
            text.AppendLine($"- {experience.Name} | {experience.Destination.DisplayName}")
                .AppendLine($"  ${experience.PricePerPerson.ToString("0", CultureInfo.InvariantCulture)} / person | {experience.DurationHours.ToString("0.#", CultureInfo.InvariantCulture)} hours | Guide: {experience.GuideName}");

        text.AppendLine().AppendLine("DEMO BOOKINGS (no real reservations)");
        if (bookings.Count == 0) text.AppendLine("No demo bookings yet.");
        foreach (var booking in bookings.OrderBy(item => item.Night))
            text.AppendLine($"- {booking.Reference} | {booking.ExperienceName}")
                .AppendLine($"  {booking.Night.ToString("MMMM d, yyyy", CultureInfo.InvariantCulture)} | {booking.Destination}")
                .AppendLine($"  {booking.Guests} guests x ${booking.PricePerPerson.ToString("0", CultureInfo.InvariantCulture)} = ${booking.Total.ToString("0", CultureInfo.InvariantCulture)} USD sample total")
                .AppendLine($"  Guest: {booking.GuestName} | Sample email: {booking.Email}");

        return text.AppendLine().AppendLine("This collection is a snapshot of your current visit. Refreshing the app resets its in-memory state.").ToString();
    }
}
