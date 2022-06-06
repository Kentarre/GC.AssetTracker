using System.Text.Json;
using GC.Api.Handlers;
using GC.Common;
using ServiceStack.Redis;

namespace GC.Api;

public class RedisClientRegistrator : BackgroundService
{
    private readonly IConfiguration _configuration;
    private readonly IHandleMessages<CoordinatesChangedEvent> _handler;

    public RedisClientRegistrator(IConfiguration configuration, IHandleMessages<CoordinatesChangedEvent> handler)
    {
        _configuration = configuration;
        _handler = handler;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var settings = _configuration
            .GetSection("Redis")
            .Get<RedisSettings>();

        Task.Run(() => RegisterListener(settings));
        
        return Task.CompletedTask;
    }

    private void RegisterListener(RedisSettings settings)
    {
        using var client = new RedisClient(settings.Host, settings.Port, settings.Pass);
        using var subscription = client.CreateSubscription();

        subscription.OnMessage += (s, msg) =>
        {
            _handler.HandleMessage(JsonSerializer.Deserialize<CoordinatesChangedEvent>(msg));
        };

        subscription.SubscribeToChannels(settings.QueueName);
    }
}