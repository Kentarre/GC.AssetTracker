using System.Text.Json;
using GC.Common;
using ServiceStack.Redis;

var queueName = "CoordinateEvents";
var coordinates = new List<(Guid id, double lat, double lng)>
{
    // Asset 1: 9339ce91-c743-4c6a-971e-feceebece838
    new(new Guid("9339ce91-c743-4c6a-971e-feceebece838"), 59.196641, 24.095769),
    new(new Guid("9339ce91-c743-4c6a-971e-feceebece838"), 59.245647, 24.279237),
    new(new Guid("9339ce91-c743-4c6a-971e-feceebece838"), 59.307380, 24.402445),
    
    // Asset 2: 
    // new (new Guid("25065afb-9c8f-4a8a-b6a3-2033b5fc6d68"), 59.262162, 25.000182),
    // new (new Guid("25065afb-9c8f-4a8a-b6a3-2033b5fc6d68"), 59.395667, 24.821440),
    // new (new Guid("25065afb-9c8f-4a8a-b6a3-2033b5fc6d68"), 59.394449, 24.822456)
    
};

using var publisher = new RedisClient("localhost", 55002, "somepass");

foreach (var coordinate in coordinates)
{
    publisher.PublishMessage(queueName,
        JsonSerializer.Serialize(new CoordinatesChangedEvent()
        {
            Asset = new Asset(coordinate.id, coordinate.lat, coordinate.lng)
        }));
    
    Thread.Sleep(1000); // Give it some time
}

