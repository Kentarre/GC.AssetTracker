namespace GC.Common;

public static class Mock
{
    public static List<(double lat, double lng, double range)> Zones = new()
    {
        new(59.4827913, 24.7016877, 0),
        new(59.4099055, 24.9062221, 5),
        new(59.2206293, 24.4115921, 10)
    };
}