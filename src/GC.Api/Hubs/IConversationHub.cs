namespace GC.Api.Hubs;

public interface IConversationHub
{
    Task PushData(Guid id, double latitude, double longitude);
}