namespace GC.Api.Helpers;

public class TwilioHelper : ITwilioHelper
{
    private readonly HttpClient _client;

    public TwilioHelper(HttpClient factory)
    {
        _client = factory;
    }

    public async Task SendNotification(Guid assetId)
    {
        await _client.GetAsync(""); //bla bla bla
    }
}