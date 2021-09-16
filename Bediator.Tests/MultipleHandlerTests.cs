using System;
using Bediator.Tests.Handlers;
using Bediator.Tests.Interfaces;
using Bediator.Tests.Messages;
using Bediator.Tests.Models;
using Bediator.Tests.Services;
using Xunit;

namespace Bediator.Tests
{
    public class MultipleHandlerTests
    {
        [Fact]
        public async void HandleSingleMessage()
        {
            var bdiator = new BDiator(new HandlerProvider());
            bdiator.Subscribe<IEventHandler<IEvent>, IEvent>();
            bdiator.Subscribe<IMessageHandler<IMessage>, IMessage>();

            var counter = new Counter();
            await bdiator.HandleAsync(new HelloMessage()
            {
                Message = "Test message",
                Counter = counter
            });
            
            Assert.Equal(1, counter.Count);
        }
        
        [Fact]
        public async void HandleMultipleMessages()
        {
            var bdiator = new BDiator(new HandlerProvider());
            bdiator.Subscribe<IMessageHandler<IMessage>, IMessage>();
            bdiator.Subscribe<IEventHandler<IEvent>, IEvent>();

            var counter = new Counter();
            var updatedCounter = new Counter();
            await bdiator.HandleAsync(new UpdatedEvent()
            {
                UpdatedTime = DateTime.Now,
                Counter = updatedCounter
            });
            await bdiator.HandleAsync(new CreatedEvent()
            {
                EventDetails = new CreatedEventDetails()
                {
                    Id = Guid.NewGuid()
                },
                Counter = counter
            });
            await bdiator.HandleAsync(new CreatedEvent()
            {
                EventDetails = new CreatedEventDetails()
                {
                    Id = Guid.NewGuid()
                },
                Counter = counter
            });
            
            Assert.Equal(2, counter.Count);
            Assert.Equal(1, updatedCounter.Count);
        }
        
        [Fact]
        public async void HandleMultipleMessagesFromDifferentHandlers()
        {
            var bdiator = new BDiator(new HandlerProvider());
            bdiator.Subscribe<IMessageHandler<IMessage>, IMessage>();
            bdiator.Subscribe<IEventHandler<IEvent>, IEvent>();

            var createdCounter = new Counter();
            var getNotified = new Counter();
            var helloCounter = new Counter();
            
            await bdiator.HandleAsync(new CreatedEvent()
            {
                EventDetails = new CreatedEventDetails()
                {
                    Id = Guid.NewGuid()
                },
                Counter = createdCounter
            });
            await bdiator.HandleAsync(new GetNotifiedMessage()
            {
                Notification = "Test notification",
                Counter = getNotified
            });
            await bdiator.HandleAsync(new HelloMessage()
            {
                Message = "Test message",
                Counter = helloCounter
            });

            Assert.Equal(1, createdCounter.Count);
            Assert.Equal(1, getNotified.Count);
            Assert.Equal(1, helloCounter.Count);
        }
    }
}