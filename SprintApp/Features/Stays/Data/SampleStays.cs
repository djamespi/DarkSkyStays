using SprintApp.Features.Discovery.Data;
using SprintApp.Features.Sky.Models;
using SprintApp.Features.Stays.Models;

namespace SprintApp.Features.Stays.Data;

public static class SampleStays
{
    public static IReadOnlyList<Stay> All { get; } =
    [
        new("aoraki-cabin", "The Aoraki Hideaway", SampleDestinations.Aoraki, StayType.Cabin,
            "A warm little cabin, a still alpine lake, and a private deck made for looking up. Slow down by the fire before stepping into a sky full of possibility.",
            185m, 4.98, 86, 2, "images/stay-alpine.svg", "A glowing timber cabin beside an alpine lake under a starry sky",
            new(1, MoonPhase.WaxingCrescent, 6, 8, "10:00 PM – 2:00 AM"),
            ["Private stargazing deck", "Telescope", "Fireplace", "Breakfast basket"]),
        new("atacama-dome", "Luna Desert Dome", SampleDestinations.Atacama, StayType.Dome,
            "Sleep close to the desert in a secluded dome surrounded by ochre hills. Your host will set out a telescope and a pot of tea for an unhurried night.",
            220m, 4.96, 64, 2, "images/stay-desert.svg", "An illuminated dome in a quiet desert valley with a crescent moon",
            new(1, MoonPhase.NewMoon, 0, 3, "9:30 PM – 3:00 AM"),
            ["Panoramic dome", "Telescope", "Desert breakfast", "Private bathroom"]),
        new("lapland-cabin", "Northlight Glass Cabin", SampleDestinations.Lapland, StayType.Cabin,
            "A glass-fronted retreat tucked between pines. Wrap yourself in a blanket, watch the changing northern sky, and let the rest of the world wait.",
            265m, 4.95, 112, 4, "images/stay-forest.svg", "A glass cabin in a pine forest beneath a soft northern aurora",
            new(2, MoonPhase.WaningCrescent, 12, 14, "9:00 PM – 1:00 AM"),
            ["Glass-fronted bedroom", "Sauna", "Warm blankets", "Forest trails"]),
        new("joshua-camp", "Juniper Moon Camp", SampleDestinations.JoshuaTree, StayType.Glamping,
            "Canvas walls, thoughtful comforts, and an open desert horizon. Settle into a hammock after sunset and find your favorite constellation.",
            125m, 4.87, 49, 2, "images/stay-camp.svg", "A warmly lit canvas tent in a secluded desert camp beneath the stars",
            new(3, MoonPhase.FirstQuarter, 48, 6, "12:00 AM – 3:00 AM"),
            ["Canvas tent", "Outdoor firepit", "Hammock", "Shared telescope"]),
        new("jasper-lodge", "Stillwater Alpine Lodge", SampleDestinations.Jasper, StayType.Cabin,
            "Bring the whole crew to a timber lodge beside the water. There is room around the table, a telescope on the deck, and plenty of sky to share.",
            310m, 4.92, 73, 6, "images/stay-alpine.svg", "A lakeside mountain lodge with warm windows at night",
            new(2, MoonPhase.WaxingCrescent, 9, 12, "10:30 PM – 2:00 AM"),
            ["Three bedrooms", "Lakeside deck", "Telescope", "Full kitchen"]),
        new("lofoten-dome", "The Quiet Fjord", SampleDestinations.Lofoten, StayType.Dome,
            "A small dome with a big view over a sheltered fjord. Come for the crisp air, stay for the long evenings beneath the northern sky.",
            240m, 4.91, 38, 2, "images/stay-fjord.svg", "A glowing dome beside a northern fjord surrounded by mountains and forest",
            new(2, MoonPhase.LastQuarter, 51, 19, "8:00 PM – 11:00 PM"),
            ["Fjord view", "Heated dome", "Breakfast", "Local walking map"])
    ];
}
