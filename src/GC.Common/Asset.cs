namespace GC.Common;

public class Asset
{
    public Guid AssetId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Asset(Guid assetId, double latitude, double longitude)
    {
        AssetId = assetId;
        Latitude = latitude;
        Longitude = longitude;
    }

    public bool IsInRange()
    {
        bool isInRange = false;
        
        foreach (var zone in Mock.Zones)
        {
            var distance = Calculate(Latitude, Longitude, zone.lat, zone.lng);
            isInRange = distance <= zone.range;
        }

        return isInRange;
    }

    private double Calculate(double lat1, double lng1, double lat2, double lng2)
    { 
        var p = 0.017453292519943295;
        var a = 0.5 - Math.Cos((lat2 - lat1) * p) / 2 +
               Math.Cos(lat1 * p) * Math.Cos(lat2 * p) * (1 - Math.Cos((lng2 - lng1) * p)) / 2;
        
        return 12742 * Math.Asin(Math.Sqrt(a));
    }
}