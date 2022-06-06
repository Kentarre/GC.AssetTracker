using GC.Api.Helpers;
using GC.Api.Hubs;
using GC.Common;
using Microsoft.AspNetCore.SignalR;

namespace GC.Api.Handlers;

public class HandleMessge : IHandleMessages<CoordinatesChangedEvent>
{
    private readonly IHubContext<ConversationHub, IConversationHub> _context;
    private readonly ITwilioHelper _helper;

    public HandleMessge(IHubContext<ConversationHub, IConversationHub> context, ITwilioHelper helper)
    {
        _context = context;
        _helper = helper;
    }

    public Task HandleMessage(CoordinatesChangedEvent message)
    {
        if (message.Asset.AssetId == Guid.Empty || message.Asset.Longitude == 0 || message.Asset.Latitude == 0) 
            return Task.CompletedTask;

        _context.Clients.All.PushData(message.Asset.AssetId, message.Asset.Latitude, message.Asset.Longitude);

        if (message.Asset.IsInRange())
            _helper.SendNotification(message.Asset.AssetId);
        
        return Task.CompletedTask;
    }
}