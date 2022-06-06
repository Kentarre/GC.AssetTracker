namespace GC.Api.Handlers;

public interface IHandleMessages<T>
{
    Task HandleMessage(T message);
}