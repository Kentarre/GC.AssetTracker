using GC.Api;
using GC.Api.Handlers;
using GC.Api.Helpers;
using GC.Api.Hubs;
using GC.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddTransient<IHandleMessages<CoordinatesChangedEvent>, HandleMessge>();
builder.Services.AddTransient<ITwilioHelper, TwilioHelper>();
builder.Services.AddHttpClient("client", c => c.BaseAddress = new Uri(""));
builder.Services.AddHostedService<RedisClientRegistrator>();

var app = builder.Build();

app.MapHub<ConversationHub>("/hubs/conversation");

app.Run();