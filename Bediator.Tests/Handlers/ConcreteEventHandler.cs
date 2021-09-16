using System.Threading.Tasks;
using Bediator.Tests.Interfaces;
using Bediator.Tests.Messages;
using Bediator.Tests.Models;

namespace Bediator.Tests.Handlers
{
    public class ConcreteTestEventHandler : IConcreteHandler<ConcreteTestEvent>
    {
        public void Handle(ConcreteTestEvent @event)
        {
            @event.Counter.Count += 1;
        }
    }
}