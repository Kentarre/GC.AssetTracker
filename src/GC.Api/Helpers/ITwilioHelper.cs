namespace GC.Api.Helpers;

public interface ITwilioHelper
{
    Task SendNotification(Guid assetId);
}