namespace SprintApp.Features.Discovery.Models;

public sealed record Destination(string Id, string Region, string Country)
{
    public string DisplayName => $"{Region}, {Country}";
}
