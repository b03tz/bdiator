using System.Threading.Tasks;

namespace Bediator.Tests.Interfaces
{
    internal interface IFaultyHandler<in TEvent>
        where TEvent : IEvent
    {
        Task HandleFaultyNamed(TEvent @event);
    }
}