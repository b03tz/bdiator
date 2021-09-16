using System.Threading.Tasks;
using Bediator.Tests.Interfaces;
using Bediator.Tests.Messages;

namespace Bediator.Tests.Handlers
{
    internal class UpdatedEventHandler : IEventHandler<UpdatedEvent>
    {
        // On purpose non-async null return
        public Task Handle(UpdatedEvent @event)
        {
            @event.Counter.Count += 1;
            return null!;
        }
    }
}