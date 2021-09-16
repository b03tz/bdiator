using System.Threading.Tasks;
using Bediator.Tests.Interfaces;
using Bediator.Tests.Messages;

namespace Bediator.Tests.Handlers
{
    public class UnregisteredEventHandler : IEventHandler<UnregisteredEvent>
    {
        public async Task Handle(UnregisteredEvent @event)
        {
            await Task.Delay(50);
        }
    }
}