using Bediator.Tests.Interfaces;
using Bediator.Tests.Messages;
using Bediator.Tests.Models;
using Bediator.Tests.Services;
using Xunit;

namespace Bediator.Tests
{
    public class ConcreteHandlerTests
    {
        [Fact]
        public async void HandleSingleMessage()
        {
            var bdiator = new BDiator(new HandlerProvider(), new BDiatorOptions
            {
                HandlerAssemblies = new[] { typeof(IMessage).Assembly }
            });
            bdiator.Subscribe<IConcreteHandler<ConcreteEvent>, ConcreteEvent>();

            var counter = new Counter();
            await bdiator.HandleAsync(new ConcreteTestEvent()
            {
                Name = "John Doe",
                Counter = counter
            });

            Assert.Equal(1, counter.Count);
        }
    }
}