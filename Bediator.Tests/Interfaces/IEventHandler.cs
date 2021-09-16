using System.Threading.Tasks;

namespace Bediator.Tests.Interfaces
{
    internal interface IEventHandler<in TEvent>
    where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event);
    }
}