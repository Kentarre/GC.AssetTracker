namespace GC.Api.Helpers;

public class TwilioHelper : ITwilioHelper
{
    private readonly IHttpClientFactory _factory;

    public TwilioHelper(IHttpClientFactory factory)
    {
        _factory = factory;
    }
    
    public async Task SendNotification(Guid assetId)
    {
        var client = _factory.CreateClient("https:");
        //client.SendAsync()
    }
}