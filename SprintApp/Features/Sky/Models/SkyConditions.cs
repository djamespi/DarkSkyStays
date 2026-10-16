namespace SprintApp.Features.Sky.Models;

/// <summary>Fictional conditions for a sample observing night; never a live forecast.</summary>
public sealed record SkyConditions(
    int BortleClass,
    MoonPhase MoonPhase,
    int MoonIlluminationPercent,
    int CloudCoverPercent,
    string ViewingWindow)
{
    public string DarknessLabel => BortleClass switch
    {
        1 => "Pristine skies",
        2 => "Truly dark skies",
        3 => "Beautiful rural skies",
        _ => "A little city glow"
    };

    public string MoonPhaseLabel => MoonPhase switch
    {
        MoonPhase.NewMoon => "New moon",
        MoonPhase.WaxingCrescent => "Waxing crescent",
        MoonPhase.FirstQuarter => "First quarter",
        MoonPhase.WaxingGibbous => "Waxing gibbous",
        MoonPhase.FullMoon => "Full moon",
        MoonPhase.WaningGibbous => "Waning gibbous",
        MoonPhase.LastQuarter => "Last quarter",
        MoonPhase.WaningCrescent => "Waning crescent",
        _ => "Unknown"
    };
}
