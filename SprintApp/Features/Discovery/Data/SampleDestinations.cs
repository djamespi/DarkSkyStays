using SprintApp.Features.Discovery.Models;

namespace SprintApp.Features.Discovery.Data;

public static class SampleDestinations
{
    public static readonly Destination Aoraki = new("aoraki", "Aoraki / Mackenzie", "New Zealand");
    public static readonly Destination Atacama = new("atacama", "Atacama Desert", "Chile");
    public static readonly Destination Lapland = new("lapland", "Finnish Lapland", "Finland");
    public static readonly Destination JoshuaTree = new("joshua-tree", "Joshua Tree", "United States");
    public static readonly Destination Jasper = new("jasper", "Jasper", "Canada");
    public static readonly Destination Lofoten = new("lofoten", "Lofoten Islands", "Norway");

    public static IReadOnlyList<Destination> All { get; } =
        [Aoraki, Atacama, Lapland, JoshuaTree, Jasper, Lofoten];
}
