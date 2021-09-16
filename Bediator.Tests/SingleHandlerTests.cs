using System.Reflection;
using Bediator.Tests.Interfaces;
using Bediator.Tests.Messages;
using Bediator.Tests.Models;
using Bediator.Tests.Services;
using Xunit;

namespace Bediator.Tests
{
    public class SingleHandlerTests
    {
        [Fact]
        public async void HandleSingleMessage()
        {
            var bdiator = new BDiator(new HandlerProvider(), new BDiatorOptions
            {
                HandlerAssemblies = new[] { typeof(IMessage).Assembly }
            });
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

            var helloCounter = new Counter();
            var getNotifiedCounter = new Counter();
            await bdiator.HandleAsync(new HelloMessage()
            {
                Message = "Test message",
                Counter = helloCounter
            });
            await bdiator.HandleAsync(new HelloMessage()
            {
                Message = "Test message",
                Counter = helloCounter
            });
            await bdiator.HandleAsync(new GetNotifiedMessage()
            {
                Notification = "Notification test",
                Counter = getNotifiedCounter
            });

            Assert.Equal(2, helloCounter.Count);
            Assert.Equal(1, getNotifiedCounter.Count);
        }
    }
}