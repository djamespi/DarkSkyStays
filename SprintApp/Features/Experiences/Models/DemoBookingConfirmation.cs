namespace SprintApp.Features.Experiences.Models;

public sealed record DemoBookingConfirmation(
    string Reference, string ExperienceId, string ExperienceName, string Destination,
    DateOnly Night, int Guests, decimal PricePerPerson, string GuestName,
    string Email, DateTimeOffset CreatedAt)
{
    public decimal Total => PricePerPerson * Guests;
}
