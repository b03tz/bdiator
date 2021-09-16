using System.Threading.Tasks;
using Bediator.Tests.Interfaces;
using Bediator.Tests.Messages;

namespace Bediator.Tests.Handlers
{
    internal class CreatedEventHandler : IEventHandler<CreatedEvent>
    {
        public async Task Handle(CreatedEvent @event)
        {
            @event.Counter.Count += 1;
            await Task.Delay(50);
        }
    }
}