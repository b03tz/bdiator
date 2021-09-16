# BDiator

A very simple mediator pattern implementation, pronounced as Mediator but with the letter B =)

Easily register multiple handlers for messages. No need for any specific implementation of BDiator so no dependencies in your use layers.

Example usage:
```c#
var bdiator = new BDiator(new HandlerProvider());
bdiator.Subscribe<IMessageHandler<IMessage>, IMessage>();
bdiator.Subscribe<IEventHandler<IEvent>, IEvent>();

await bdiator.HandleAsync(new UpdatedEvent()
{
    UpdatedTime = DateTime.Now
});

await bdiator.HandleAsync(new CreatedEvent()
{
    EventDetails = new CreatedEventDetails()
    {
        Id = Guid.NewGuid()
    }
});

await bdiator.HandleAsync(new CreatedEvent()
{
    EventDetails = new CreatedEventDetails()
    {
        Id = Guid.NewGuid()
    }
});
```

Setup the handler provider to get your eventhandlers from a DI system and off you go!