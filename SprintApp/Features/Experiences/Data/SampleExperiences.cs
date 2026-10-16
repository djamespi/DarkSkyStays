using SprintApp.Features.Discovery.Data;
using SprintApp.Features.Experiences.Models;
using SprintApp.Features.Sky.Models;

namespace SprintApp.Features.Experiences.Data;

public static class SampleExperiences
{
    public static IReadOnlyList<TourExperience> All { get; } =
    [
        new("mackenzie-stars", "A thousand stars & a cup of cocoa", SampleDestinations.Aoraki,
            ExperienceType.Stargazing, "An easygoing small-group evening with a local sky guide. Get to know the constellations, take a turn at the telescope, and warm your hands around a mug of cocoa.",
            65m, 2, 8, 4.98, "images/stay-alpine.svg", "Alex",
            new(1, MoonPhase.WaxingCrescent, 6, 8, "10:00 PM – 12:00 AM"),
            ["Local guide", "Telescope time", "Hot cocoa", "Warm blankets"]),
        new("atacama-photo", "Chasing the Milky Way", SampleDestinations.Atacama,
            ExperienceType.Astrophotography, "Head into the desert with a photographer who will help you capture your own piece of the night. Beginners are welcome; bring a camera with manual controls.",
            95m, 3, 6, 4.96, "images/stay-desert.svg", "Sofia",
            new(1, MoonPhase.NewMoon, 0, 3, "10:00 PM – 1:00 AM"),
            ["Photography guide", "Tripod loan", "Camera setup help", "Tea and snacks"]),
        new("lapland-walk", "Into the northern night", SampleDestinations.Lapland,
            ExperienceType.NightWalk, "Follow a gentle forest trail with a local guide, then pause in a clearing for stories, quiet sky watching, and a warm drink by the fire. Aurora sightings are never guaranteed.",
            75m, 2.5, 8, 4.94, "images/stay-forest.svg", "Elli",
            new(2, MoonPhase.WaningCrescent, 12, 14, "9:00 PM – 11:30 PM"),
            ["Forest guide", "Headlamp", "Warm drink", "Fireside snack"]),
        new("jasper-family", "Little explorers, big universe", SampleDestinations.Jasper,
            ExperienceType.Stargazing, "A family-friendly introduction to the sky with constellation stories and a relaxed telescope session. Curious questions and cozy layers encouraged.",
            45m, 1.5, 10, 4.91, "images/stay-alpine.svg", "Jordan",
            new(2, MoonPhase.WaxingCrescent, 9, 12, "9:00 PM – 10:30 PM"),
            ["Family sky guide", "Telescope time", "Constellation activity", "Hot chocolate"])
    ];
}
