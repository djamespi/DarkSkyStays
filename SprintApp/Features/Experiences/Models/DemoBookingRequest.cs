using System.ComponentModel.DataAnnotations;

namespace SprintApp.Features.Experiences.Models;

public sealed class DemoBookingRequest
{
    [Required(ErrorMessage = "Tell us your name.")]
    [StringLength(80, MinimumLength = 2, ErrorMessage = "Use a name between 2 and 80 characters.")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Enter an email address for your sample confirmation.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    [StringLength(120, ErrorMessage = "Use an email address of 120 characters or fewer.")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Choose a night to explore.")]
    public DateTime? Night { get; set; }

    [Range(1, 10, ErrorMessage = "Choose between 1 and 10 guests.")]
    public int Guests { get; set; } = 2;
}
